using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task.Management;

namespace Task.TPSControls
{
    public class TPSCamera : MonoBehaviour
    {
        // Private Fields
        float mouseX;
        float mouseY;


        // Serialized Fields
        //[SerializeField] private Transform _camera;
        [SerializeField] private CameraSetting _setting;
        [SerializeField] private Transform _target;

        // GameManager Cache
        private GameManager _gameManager;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Start()
        {
            _gameManager = GameManager.singleton;
        }

        private void Update()
        {
            if (!_gameManager.isUIActive)
            {
                
                mouseX += Input.GetAxis("Mouse X") * _setting.sensitivity * Time.deltaTime;
                mouseY += Input.GetAxis("Mouse Y") * _setting.sensitivity * Time.deltaTime;

                mouseY = Mathf.Clamp(mouseY, _setting.angleMin, _setting.angleMax);
                transform.eulerAngles = new Vector3(-mouseY, mouseX);
                
                
                
            }
            transform.position = _target.position - (transform.forward * _setting.distance);
        }
    }
}