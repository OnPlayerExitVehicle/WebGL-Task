using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task.Management;
using Task.TPSControls;
using UnityEngine.UI;

namespace Task.UI
{
    public class UIController : MonoBehaviour
    {
        // Serialized Fields
        [SerializeField] private GameObject _ui;
        [SerializeField] private Slider _slider;
        [SerializeField] private CameraSetting _setting;

        // GameManager Cache
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.singleton;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                OnRightClickStart();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                OnRightClickEnd();
            }
        }
        public void OnRightClickStart()
        {
            _ui.SetActive(true);
            _gameManager.isUIActive = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void OnRightClickEnd()
        {
            _ui.SetActive(false);
            _gameManager.isUIActive = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnClick()
        {
            _gameManager.playerAnimator.SetBool("isDancing", !_gameManager.isDancing);
            _gameManager.isDancing = !_gameManager.isDancing;
        }

        public void OnValueChanged()
        {
            _setting.sensitivity = _slider.value;
        }
    }
}
