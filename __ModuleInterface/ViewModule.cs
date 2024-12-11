
namespace Scripts.Systems.Camera.GridView
{
    public class ViewModule
    {
        private readonly IGidViewer _gridViewer;
        
        internal ViewModule(IGidViewer viewer) {
            _gridViewer = viewer;
        }

        /*public void SetSwapAllow(bool swapAllow) {
            _gridViewer.SwapComponent.IsSwapAllows = swapAllow;
        }*/
    }
}