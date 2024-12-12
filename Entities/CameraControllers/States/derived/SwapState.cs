namespace Scripts.Systems.Camera.GridView
{
    internal class SwapState : CameraState
    {
        protected readonly ISwapper _swapper;

        internal SwapState(ISwapper swapper) {
            _swapper = swapper;
        }

        internal override void Update() {
            _swapper.HandleSwap();
        }
    }
}