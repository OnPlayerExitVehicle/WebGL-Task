using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task.Management;
using Task.Extensions;

namespace Task.TPSControls
{
    //[RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class TPSMovement : MonoBehaviour
    {
        // Serialized Fields
        [SerializeField] private Transform _camera;

        // Private Fields
        private int walkingHash;
        private int runningHash;
        private int dancingHash;

        // Component References
        private Rigidbody _rigidBody;
        private Animator _animator;
        private CharacterController _characterController;

        // Settings
        [SerializeField] private MovementSetting _setting;

        // GameManager Cache
        private GameManager _gameManager;

        private void Awake()
        {
            //_rigidBody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            walkingHash = Animator.StringToHash("isWalking");
            runningHash = Animator.StringToHash("isRunning");
            dancingHash = Animator.StringToHash("isDancing");
        }

        private void Start()
        {
            _gameManager = GameManager.singleton;
            _gameManager.SetAnimator(_animator);
        }

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (!_gameManager.isUIActive)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _animator.SetBool(runningHash, true);
                }
                else
                {
                    _animator.SetBool(runningHash, false);
                }

                bool forward = Input.GetKey(KeyCode.W);
                bool left = Input.GetKey(KeyCode.A);
                bool right = Input.GetKey(KeyCode.D);
                bool backward = Input.GetKey(KeyCode.S);

                Vector3 targetDirection = Vector3.zero;

                if (forward)
                {
                    targetDirection += _camera.forward;
                }

                if (backward)
                {
                    targetDirection -= _camera.forward;
                }

                if (left)
                {
                    targetDirection -= _camera.right;
                }

                if (right)
                {
                    targetDirection += _camera.right;

                }

                if (forward || backward || left || right)
                {
                    float angleBetween = Vector3.up.AngleSigned(transform.forward, targetDirection);
                    if (Mathf.Abs(angleBetween) > 5f)
                    {
                        Debug.Log(angleBetween);
                        transform.Rotate(Vector3.up, angleBetween * _setting.rotationSpeed * Time.deltaTime);
                        //_camera.RotateAround(transform.position, Vector3.up, -angleBetween * _setting.rotationSpeed * Time.deltaTime);
                    }
                    else
                    {
                        _animator.SetBool(walkingHash, true);
                        _animator.SetBool(dancingHash, false);
                    }

                }
                else
                {
                    _animator.SetBool(walkingHash, false);
                    _animator.SetBool(runningHash, false);
                }
            }
            else
            {
                _animator.SetBool(walkingHash, false);
                _animator.SetBool(runningHash, false);
            }
        }
    }
}
