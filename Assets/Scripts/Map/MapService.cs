using Zenject;

namespace Map
{
    public class MapService : IMapService, IInitializable
    {
        [Inject] private MapPercentageHandler percentageHandler;
        [Inject] private MapRepository        mapRepository;

        public void Initialize()
        {
            mapRepository.SetMapService(this);
        }

        public float GetPaintPercentage() => percentageHandler.GetPaintPercentage();
    }
}