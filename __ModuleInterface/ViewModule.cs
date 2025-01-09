namespace Scripts.Systems.Camera.GridView
{
    public class ViewModule
    {
        private readonly LocationViewController _locationViewController;

        public SwapState SwapState { get; }
        public FocusState FocusState { get; }

        internal ViewModule(LocationViewController viewer, SwapState swapState, FocusState focusState) {
            _locationViewController = viewer;
            
            SwapState = swapState;
            FocusState = focusState;
        }
        
        public void SetState(CameraState state) => _locationViewController.SwitchState(state);
    }
}