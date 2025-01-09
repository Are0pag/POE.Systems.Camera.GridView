namespace Scripts.Systems.Camera.GridView
{
    public interface ISwapContextSettingsRequestHandler : IExternalGridViewEventHandler
    {
        void GetContextSettings(ISwapContextContainer container);
    }
}