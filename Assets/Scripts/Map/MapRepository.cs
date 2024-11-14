namespace Map
{
    public class MapRepository
    {
        private IMapService mapService;

        public void SetMapService(IMapService mapService) => this.mapService = mapService;

        public IMapService GetMapService() => mapService;
    }
}