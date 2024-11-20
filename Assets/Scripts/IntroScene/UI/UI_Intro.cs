using SceneTransition;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

namespace IntroScene
{
    public class UI_Intro : MonoBehaviour
    {
        [Inject] private readonly ISceneService sceneService;

        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private VideoClip   videoA;
        [SerializeField] private VideoClip   videoB;

        private void Start()
        {
            videoPlayer.clip = videoA;
            videoPlayer.Play();

            videoPlayer.loopPointReached += OnVideoEnd;
        }

        private void OnVideoEnd(VideoPlayer vp)
        {
            if (videoPlayer.clip == videoA)
            {
                videoPlayer.clip = videoB;
                videoPlayer.Play();
            }
            else if (videoPlayer.clip == videoB)
            {
                sceneService.LoadScene(1);
            }
        }
    }
}