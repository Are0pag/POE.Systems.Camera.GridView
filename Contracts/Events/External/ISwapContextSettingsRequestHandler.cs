namespace Scripts.Systems.Camera.GridView
{
    public interface ISwapContextSettingsRequestHandler : IExternalGridViewEventHandler
    {
        void GetContextSettings(ISwapContextContainer container);
    }

    public interface ISwapContextContainer
    {
        SwapContextSettings SwapContextSettings { get; set; }
    }
}