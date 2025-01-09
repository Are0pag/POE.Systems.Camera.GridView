using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;
using Scripts.Services.EventBus;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    public class FocusState : CameraState, IFocusTargetContainer
    {
        protected private readonly IFocusable _focusable;
        protected private readonly IFocusCatcher _focusCatcher;

        protected bool _isFocused;
        protected Transform _target;

        public Transform Target {
            get => _target;
            set {
                _isFocused = false;
                _target = value;
                OnFocusTarget();
            }
        }

        internal FocusState(IFocusable focusable, IFocusCatcher focusCatcher) {
            _focusable = focusable;
            _focusCatcher = focusCatcher;
        }

        internal override async void OnEnterState() {
            if (!Target)
                EventBus<IExternalGridViewEventHandler>
                   .RaiseEvent<IFocusTargetRequestHandler>(h => h.GetTarget(this));

            if (!Target)
                return;

            await MoveToTarget();

            _isFocused = true;
        }

        internal override void UpdateState() {
            if (_isFocused && Target)
                _focusable.Follow(Target);
        }

        internal override void OnExitState() {
            Target = null;
            _isFocused = false;
        }

        protected async void OnFocusTarget() {
            if (Target)
                await MoveToTarget();

            _isFocused = true;
        }

        protected async UniTask MoveToTarget() {
            await _focusCatcher.MoveAt(new MoveToSelectedItemArgs(Target.position));
        }
    }
}