using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal class CameraState
    {
        internal virtual async UniTask OnEnter() {
            await UniTask.Yield();
        }

        internal virtual void Update() {
            
        }

        internal virtual void OnSwitch() {

        }
    }
}