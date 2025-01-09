namespace Scripts.Systems.Camera.LocationView
{
    public class SwapState : CameraState
    {
        protected private readonly ISwapper _swapper;

        internal SwapState(ISwapper swapper) {
            _swapper = swapper;
        }

        internal override void UpdateState() {
            _swapper.HandleSwap();
        }
    }
}