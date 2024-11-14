using System.Collections;
using Audio;
using Menu;
using MenuScene.Types;
using Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace MenuScene
{
    [ExecuteInEditMode]
    public class UI_StoryBoard : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly IMenuService  menuService;

        [SerializeField] private Canvas        canvas;
        [SerializeField] private RectTransform BookPanel;
        [SerializeField] private Sprite        background;
        [SerializeField] private Sprite[]      bookPages;
        [SerializeField] private bool          interactable = true;
        [SerializeField] private Image         ClippingPlane;
        [SerializeField] private Image         NextPageClip;
        [SerializeField] private Image         Shadow;
        [SerializeField] private Image         ShadowLTR;
        [SerializeField] private Image         Left;
        [SerializeField] private Image         LeftNext;
        [SerializeField] private Image         Right;
        [SerializeField] private Image         RightNext;
        [SerializeField] private UnityEvent    OnFlip;
        [SerializeField] private AudioSource   audioSource;
        [SerializeField] private AudioClip     audioClip;

        public bool enableShadowEffect = true;


        //represent the index of the sprite shown in the right page
        private int currentPage;

        private Vector3 endBottomLeft;
        private Vector3 endBottomRight;
        private float   radius1, radius2;

        private Vector3 spineBottom;
        private Vector3 spineTop;
        private Vector3 pageCorner;

        private Vector3        followPoint; //follow point
        private bool           pageDragging;
        private StoryBoardMode mode; //current flip mode

        private void OnEnable()
        {
            signalBus.Subscribe<OnMenuStateChanged>(OnMenuStateChanged);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<OnMenuStateChanged>(OnMenuStateChanged);
        }

        private void OnMenuStateChanged(OnMenuStateChanged e)
        {
            if (e.state == MenuState.StoryBoard)
                SetAppear(true);
        }

        public void Button_CloseStoryBoard()
        {
            SetAppear(false);
            audioService.PlayButtonClickAudio();
            menuService.ChangeMenuState(MenuState.Menu);
        }

        private void Start()
        {
            if (!canvas) canvas = GetComponentInParent<Canvas>();
            if (!canvas) Debug.LogError("Book should be a child to canvas");

            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            UpdateSprites();
            CalcCurlCriticalPoints();

            var pageWidth  = BookPanel.rect.width / 2.0f;
            var pageHeight = BookPanel.rect.height;
            NextPageClip.rectTransform.sizeDelta = new Vector2(pageWidth, pageHeight + pageHeight * 2);


            ClippingPlane.rectTransform.sizeDelta =
                new Vector2(pageWidth * 2 + pageHeight, pageHeight + pageHeight * 2);

            //hypotenuse (diagonal) page length
            var hypotenusePageLength = Mathf.Sqrt(pageWidth * pageWidth + pageHeight * pageHeight);
            var shadowPageHeight     = pageWidth / 2 + hypotenusePageLength;

            Shadow.rectTransform.sizeDelta = new Vector2(pageWidth, shadowPageHeight);
            Shadow.rectTransform.pivot     = new Vector2(1,         (pageWidth / 2) / shadowPageHeight);

            ShadowLTR.rectTransform.sizeDelta = new Vector2(pageWidth, shadowPageHeight);
            ShadowLTR.rectTransform.pivot     = new Vector2(0,         (pageWidth / 2) / shadowPageHeight);
        }

        private void CalcCurlCriticalPoints()
        {
            spineBottom    = new Vector3(0, -BookPanel.rect.height / 2);
            endBottomRight = new Vector3(BookPanel.rect.width      / 2, -BookPanel.rect.height / 2);
            endBottomLeft  = new Vector3(-BookPanel.rect.width     / 2, -BookPanel.rect.height / 2);
            spineTop       = new Vector3(0,                             BookPanel.rect.height  / 2);
            radius1        = Vector2.Distance(spineBottom, endBottomRight);

            var pageWidth  = BookPanel.rect.width / 2.0f;
            var pageHeight = BookPanel.rect.height;

            radius2 = Mathf.Sqrt(pageWidth * pageWidth + pageHeight * pageHeight);
        }

        private Vector3 TransformPoint(Vector3 mouseScreenPos)
        {
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                var mouseWorldPos =
                    canvas.worldCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y,
                                                                      canvas.planeDistance));
                Vector2 localPos = BookPanel.InverseTransformPoint(mouseWorldPos);

                return localPos;
            }

            if (canvas.renderMode == RenderMode.WorldSpace)
            {
                var ray       = Camera.main!.ScreenPointToRay(Input.mousePosition);
                var globalEBR = transform.TransformPoint(endBottomRight);
                var globalEBL = transform.TransformPoint(endBottomLeft);
                var globalSt  = transform.TransformPoint(spineTop);
                var plane     = new Plane(globalEBR, globalEBL, globalSt);

                plane.Raycast(ray, out var distance);

                Vector2 localPos = BookPanel.InverseTransformPoint(ray.GetPoint(distance));

                return localPos;
            }
            else
            {
                //Screen Space Overlay
                Vector2 localPos = BookPanel.InverseTransformPoint(mouseScreenPos);
                return localPos;
            }
        }

        private void Update()
        {
            if (pageDragging && interactable)
            {
                UpdateBook();
            }
        }

        private void UpdateBook()
        {

            followPoint = Vector3.Lerp(followPoint, TransformPoint(Input.mousePosition), Time.deltaTime * 10);
            if (mode == StoryBoardMode.RightToLeft)
                UpdateBookRTLToPoint(followPoint);
            else
                UpdateBookLTRToPoint(followPoint);
        }

        private void UpdateBookLTRToPoint(Vector3 followLocation)
        {
            mode        = StoryBoardMode.LeftToRight;
            followPoint = followLocation;
            ShadowLTR.transform.SetParent(ClippingPlane.transform, true);
            ShadowLTR.transform.localPosition    = new Vector3(0, 0, 0);
            ShadowLTR.transform.localEulerAngles = new Vector3(0, 0, 0);
            Left.transform.SetParent(ClippingPlane.transform, true);

            Right.transform.SetParent(BookPanel.transform, true);
            Right.transform.localEulerAngles = Vector3.zero;
            LeftNext.transform.SetParent(BookPanel.transform, true);

            pageCorner = Calc_C_Position(followLocation);
            Vector3 t1;
            float   clipAngle = CalcClipAngle(pageCorner, endBottomLeft, out t1);
            //0 < T0_T1_Angle < 180
            clipAngle = (clipAngle + 180) % 180;

            ClippingPlane.transform.localEulerAngles = new Vector3(0, 0, clipAngle - 90);
            ClippingPlane.transform.position         = BookPanel.TransformPoint(t1);

            //page position and angle
            Left.transform.position = BookPanel.TransformPoint(pageCorner);
            float C_T1_dy    = t1.y - pageCorner.y;
            float C_T1_dx    = t1.x - pageCorner.x;
            float C_T1_Angle = Mathf.Atan2(C_T1_dy, C_T1_dx) * Mathf.Rad2Deg;
            Left.transform.localEulerAngles = new Vector3(0, 0, C_T1_Angle - 90 - clipAngle);

            NextPageClip.transform.localEulerAngles = new Vector3(0, 0, clipAngle - 90);
            NextPageClip.transform.position         = BookPanel.TransformPoint(t1);
            LeftNext.transform.SetParent(NextPageClip.transform, true);
            Right.transform.SetParent(ClippingPlane.transform, true);
            Right.transform.SetAsFirstSibling();

            ShadowLTR.rectTransform.SetParent(Left.rectTransform, true);
        }

        private void UpdateBookRTLToPoint(Vector3 followLocation)
        {
            mode        = StoryBoardMode.RightToLeft;
            followPoint = followLocation;
            Shadow.transform.SetParent(ClippingPlane.transform, true);
            Shadow.transform.localPosition    = Vector3.zero;
            Shadow.transform.localEulerAngles = Vector3.zero;
            Right.transform.SetParent(ClippingPlane.transform, true);

            Left.transform.SetParent(BookPanel.transform, true);
            Left.transform.localEulerAngles = Vector3.zero;
            RightNext.transform.SetParent(BookPanel.transform, true);
            pageCorner = Calc_C_Position(followLocation);

            var clipAngle = CalcClipAngle(pageCorner, endBottomRight, out var t1);

            if (clipAngle > -90) clipAngle += 180;

            ClippingPlane.rectTransform.pivot        = new Vector2(1, 0.35f);
            ClippingPlane.transform.localEulerAngles = new Vector3(0, 0, clipAngle + 90);
            ClippingPlane.transform.position         = BookPanel.TransformPoint(t1);

            //page position and angle
            Right.transform.position = BookPanel.TransformPoint(pageCorner);
            float C_T1_dy    = t1.y - pageCorner.y;
            float C_T1_dx    = t1.x - pageCorner.x;
            float C_T1_Angle = Mathf.Atan2(C_T1_dy, C_T1_dx) * Mathf.Rad2Deg;
            Right.transform.localEulerAngles = new Vector3(0, 0, C_T1_Angle - (clipAngle + 90));

            NextPageClip.transform.localEulerAngles = new Vector3(0, 0, clipAngle + 90);
            NextPageClip.transform.position         = BookPanel.TransformPoint(t1);
            RightNext.transform.SetParent(NextPageClip.transform, true);
            Left.transform.SetParent(ClippingPlane.transform, true);
            Left.transform.SetAsFirstSibling();

            Shadow.rectTransform.SetParent(Right.rectTransform, true);
        }

        private float CalcClipAngle(Vector3 c, Vector3 bookCorner, out Vector3 t1)
        {
            var t0              = (c + bookCorner) / 2;
            var T0_CORNER_dy    = bookCorner.y - t0.y;
            var T0_CORNER_dx    = bookCorner.x - t0.x;
            var T0_CORNER_Angle = Mathf.Atan2(T0_CORNER_dy, T0_CORNER_dx);

            var T1_X = t0.x - T0_CORNER_dy * Mathf.Tan(T0_CORNER_Angle);
            T1_X = NormalizeT1X(T1_X, bookCorner, spineBottom);
            t1   = new Vector3(T1_X, spineBottom.y, 0);

            //clipping plane angle=T0_T1_Angle
            var T0_T1_dy    = t1.y - t0.y;
            var T0_T1_dx    = t1.x - t0.x;
            var T0_T1_Angle = Mathf.Atan2(T0_T1_dy, T0_T1_dx) * Mathf.Rad2Deg;
            return T0_T1_Angle;
        }

        private static float NormalizeT1X(float t1, Vector3 corner, Vector3 sb)
        {
            if (t1 > sb.x && sb.x > corner.x)
                return sb.x;
            if (t1 < sb.x && sb.x < corner.x)
                return sb.x;
            return t1;
        }

        private Vector3 Calc_C_Position(Vector3 followLocation)
        {
            Vector3 c;
            followPoint = followLocation;

            var F_SB_dy = followPoint.y - spineBottom.y;
            var F_SB_dx = followPoint.x - spineBottom.x;
            var F_SB_Angle = Mathf.Atan2(F_SB_dy, F_SB_dx);
            var r1 = new Vector3(radius1 * Mathf.Cos(F_SB_Angle), radius1 * Mathf.Sin(F_SB_Angle), 0) + spineBottom;

            float F_SB_distance = Vector2.Distance(followPoint, spineBottom);
            if (F_SB_distance < radius1)
                c = followPoint;
            else
                c = r1;
            float F_ST_dy    = c.y - spineTop.y;
            float F_ST_dx    = c.x - spineTop.x;
            float F_ST_Angle = Mathf.Atan2(F_ST_dy, F_ST_dx);
            Vector3 r2 = new Vector3(radius2 * Mathf.Cos(F_ST_Angle),
                                     radius2 * Mathf.Sin(F_ST_Angle), 0) + spineTop;
            float C_ST_distance = Vector2.Distance(c, spineTop);
            if (C_ST_distance > radius2)
                c = r2;
            return c;
        }

        private void DragRightPageToPoint(Vector3 point)
        {
            if (currentPage >= bookPages.Length) return;
            pageDragging = true;
            mode         = StoryBoardMode.RightToLeft;
            followPoint  = point;


            NextPageClip.rectTransform.pivot  = new Vector2(0, 0.12f);
            ClippingPlane.rectTransform.pivot = new Vector2(1, 0.35f);

            Left.gameObject.SetActive(true);
            Left.rectTransform.pivot   = new Vector2(0, 0);
            Left.transform.position    = RightNext.transform.position;
            Left.transform.eulerAngles = new Vector3(0, 0, 0);
            Left.sprite                = (currentPage < bookPages.Length) ? bookPages[currentPage] : background;
            Left.transform.SetAsFirstSibling();

            Right.gameObject.SetActive(true);
            Right.transform.position = RightNext.transform.position;
            Right.transform.eulerAngles = new Vector3(0, 0, 0);
            Right.sprite = (currentPage < bookPages.Length - 1) ? bookPages[currentPage + 1] : background;

            RightNext.sprite = (currentPage < bookPages.Length - 2) ? bookPages[currentPage + 2] : background;

            LeftNext.transform.SetAsFirstSibling();
            if (enableShadowEffect) Shadow.gameObject.SetActive(true);
            UpdateBookRTLToPoint(followPoint);
        }

        public void OnMouseDragRightPage()
        {
            if (interactable)
                DragRightPageToPoint(TransformPoint(Input.mousePosition));
        }

        private void DragLeftPageToPoint(Vector3 point)
        {
            if (currentPage <= 0) return;
            pageDragging = true;
            mode         = StoryBoardMode.LeftToRight;
            followPoint  = point;

            NextPageClip.rectTransform.pivot  = new Vector2(1, 0.12f);
            ClippingPlane.rectTransform.pivot = new Vector2(0, 0.35f);

            Right.gameObject.SetActive(true);
            Right.transform.position    = LeftNext.transform.position;
            Right.sprite                = bookPages[currentPage - 1];
            Right.transform.eulerAngles = new Vector3(0, 0, 0);
            Right.transform.SetAsFirstSibling();

            Left.gameObject.SetActive(true);
            Left.rectTransform.pivot   = new Vector2(1, 0);
            Left.transform.position    = LeftNext.transform.position;
            Left.transform.eulerAngles = new Vector3(0, 0, 0);
            Left.sprite                = (currentPage >= 2) ? bookPages[currentPage - 2] : background;

            LeftNext.sprite = (currentPage >= 3) ? bookPages[currentPage - 3] : background;

            RightNext.transform.SetAsFirstSibling();
            if (enableShadowEffect) ShadowLTR.gameObject.SetActive(true);
            UpdateBookLTRToPoint(followPoint);
        }

        public void OnMouseDragLeftPage()
        {
            if (interactable)
                DragLeftPageToPoint(TransformPoint(Input.mousePosition));
        }

        public void OnMouseRelease()
        {
            if (interactable)
                ReleasePage();
        }

        private void ReleasePage()
        {
            if (!pageDragging)
                return;

            pageDragging = false;
            var distanceToLeft  = Vector2.Distance(pageCorner, endBottomLeft);
            var distanceToRight = Vector2.Distance(pageCorner, endBottomRight);

            if (distanceToRight < distanceToLeft && mode == StoryBoardMode.RightToLeft)
                TweenBack();
            else if (distanceToRight > distanceToLeft && mode == StoryBoardMode.LeftToRight)
                TweenBack();
            else
                TweenForward();
        }

        private Coroutine currentCoroutine;

        private void UpdateSprites()
        {
            LeftNext.sprite = (currentPage > 0 && currentPage <= bookPages.Length)
                                  ? bookPages[currentPage - 1]
                                  : background;
            RightNext.sprite = (currentPage >= 0 && currentPage < bookPages.Length)
                                   ? bookPages[currentPage]
                                   : background;
        }

        private void TweenForward()
        {
            if (mode == StoryBoardMode.RightToLeft)
                currentCoroutine = StartCoroutine(TweenTo(endBottomLeft, 0.15f, () => { Flip(); }));
            else
                currentCoroutine = StartCoroutine(TweenTo(endBottomRight, 0.15f, () => { Flip(); }));
        }

        private void Flip()
        {
            if (mode == StoryBoardMode.RightToLeft)
                currentPage += 2;
            else
                currentPage -= 2;
            LeftNext.transform.SetParent(BookPanel.transform, true);
            Left.transform.SetParent(BookPanel.transform, true);
            LeftNext.transform.SetParent(BookPanel.transform, true);
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Right.transform.SetParent(BookPanel.transform, true);
            RightNext.transform.SetParent(BookPanel.transform, true);
            UpdateSprites();
            Shadow.gameObject.SetActive(false);
            ShadowLTR.gameObject.SetActive(false);
            if (OnFlip != null)
                OnFlip.Invoke();
        }

        private void TweenBack()
        {
            if (mode == StoryBoardMode.RightToLeft)
            {
                currentCoroutine = StartCoroutine(TweenTo(endBottomRight, 0.15f,
                                                          () =>
                                                          {
                                                              UpdateSprites();
                                                              // audioService.StartAudio(audioSource);
 
                                                              RightNext.transform.SetParent(BookPanel.transform);
                                                              Right.transform.SetParent(BookPanel.transform);

                                                              Left.gameObject.SetActive(false);
                                                              Right.gameObject.SetActive(false);
                                                              pageDragging = false;
                                                          }
                                                         ));
            }
            else
            {
                currentCoroutine = StartCoroutine(TweenTo(endBottomLeft, 0.15f,
                                                          () =>
                                                          {
                                                              UpdateSprites();
                                                              // audioService.StartAudio(audioSource);

                                                              LeftNext.transform.SetParent(BookPanel.transform);
                                                              Left.transform.SetParent(BookPanel.transform);

                                                              Left.gameObject.SetActive(false);
                                                              Right.gameObject.SetActive(false);
                                                              pageDragging = false;
                                                          }
                                                         ));
            }
        }

        private IEnumerator TweenTo(Vector3 to, float duration, System.Action onFinish)
        {
            var steps        = (int)(duration / 0.025f);
            var displacement = (to - followPoint) / steps;

            for (var i = 0; i < steps - 1; i++)
            {
                if (mode == StoryBoardMode.RightToLeft)
                    UpdateBookRTLToPoint(followPoint + displacement);
                else
                    UpdateBookLTRToPoint(followPoint + displacement);

                yield return new WaitForSeconds(0.025f);
            }

            onFinish?.Invoke(); //TODO: FIX AUDIO
        }
    }
}