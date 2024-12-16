namespace Scripts.Systems.Camera.GridView
{
    internal interface IZoomHandler : IGridViewSubscriber
    {
        void ZoomIn();
        void ZoomOut();
    }
}