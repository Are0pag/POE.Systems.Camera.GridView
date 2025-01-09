namespace Scripts.Systems.Camera.LocationView
{
    public interface ISwapContextSettingsRequestHandler : IExternalLocationViewEventSubscriber
    {
        void GetContextSettings(ISwapContextContainer container);
    }
}