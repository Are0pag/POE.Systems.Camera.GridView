namespace Scripts.Systems.Camera.GridView
{
    public class SwapState : CameraState
    {
        protected private readonly ISwapper _swapper;

        internal SwapState(ISwapper swapper) {
            _swapper = swapper;
        }

        internal override void Update() {
            _swapper.HandleSwap();
        }
    }
}