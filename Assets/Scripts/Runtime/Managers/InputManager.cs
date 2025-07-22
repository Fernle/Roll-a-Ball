using Runtime.Keys;
using Runtime.Signals;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private float2 _inputValues;

        #endregion

        #endregion
        
        private void Update()
        {
            _inputValues = GetInputValues();
            if(!Input.anyKey) return;
            SendInput();
        }

        private void SendInput()
        {
            InputSignals.Instance.OnInputTaken?.Invoke( new InputParams { InputValues = _inputValues });
        }

        private float2 GetInputValues()
        {
            return new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}
