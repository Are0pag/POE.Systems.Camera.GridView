namespace Scripts.Systems.Camera.LocationView
{
    public interface IInputHandler : IExternalLocationViewEventSubscriber
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
}