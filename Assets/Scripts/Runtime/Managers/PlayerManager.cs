using Runtime.Controllers;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #region Private Variables

        private PlayerData _playerData;

        #endregion

        #endregion

        private void Awake()
        {
            GetPlayerData();
            SendDataToControllers();
        }

        private void GetPlayerData()
        {
            _playerData = Resources.Load<CD_Player>("Data/CD_Player").Data;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.OnInputTaken += playerMovementController.OnInputTaken;
        }
        
        private void UnsubscribeEvents()
        {
            InputSignals.Instance.OnInputTaken -= playerMovementController.OnInputTaken;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void SendDataToControllers()
        {
            playerMovementController.SetMovementData(_playerData.MovementData);
        }
    }
}