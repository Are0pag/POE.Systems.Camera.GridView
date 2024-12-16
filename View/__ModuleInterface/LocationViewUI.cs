using System;

namespace Scripts.Systems.Camera.GridView.View
{
    public class LocationViewUI
    {
        protected private readonly CameraModeInput _cameraModeInput;

        internal LocationViewUI(CameraModeInput cameraModeInput) {
            _cameraModeInput = cameraModeInput;
        }

        /* Action - некая инструкция управляющих систем, данный модуль не должен знать о типе действия, которое будет выполнять,
            следовательно не может устанавливать тип принимаемого параметра */
        
        public void InitializeCameraModeInput(Action focusButtonAction, Action swapButtonAction) {
            _cameraModeInput.InitTopDown(focusButtonAction, swapButtonAction);
        }
    }
}