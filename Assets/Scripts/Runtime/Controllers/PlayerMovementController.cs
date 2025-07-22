using System;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using Runtime.Managers;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;

        #endregion

        #region Private Variables

        private float2 _inputValues;
        private Rigidbody _rigidbody;
        private PlayerMovementData _data;

        #endregion

        #endregion
        
        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        internal void SetMovementData(PlayerMovementData movementData)
        {
            _data = movementData;
        }

        internal void OnInputTaken(InputParams inputParams)
        {
            _inputValues = inputParams.InputValues;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            _rigidbody.linearVelocity += new Vector3(_inputValues.x, 0, _inputValues.y) * (_data.Speed * Time.fixedDeltaTime);
        }
    }
}