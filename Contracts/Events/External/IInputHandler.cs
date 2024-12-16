namespace Scripts.Systems.Camera.GridView
{
    public interface IInputHandler : IExternalGridViewEventHandler
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
}