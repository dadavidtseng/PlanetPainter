using Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameScene
{
    public class UI_Percentage : MonoBehaviour
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly MapRepository mapRepository;

        [SerializeField] private TextMeshProUGUI percentageText;
        [SerializeField] private Slider          progressBarSlider;

        private void Update()
        {
            percentageText.text     = $"{mapRepository.GetMapService().GetPaintPercentage()}%";
            progressBarSlider.value = mapRepository.GetMapService().GetPaintPercentage();
        }
    }
}