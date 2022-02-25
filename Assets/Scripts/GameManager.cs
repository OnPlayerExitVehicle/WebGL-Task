using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task.UI;

namespace Task.Management
{
    public class GameManager : MonoBehaviour
    {
        // Singleton
        public static GameManager singleton;

        // Public Fields
        public bool isUIActive;
        public Animator playerAnimator;
        public UIController uiController;
        public bool isDancing;

        private void Awake()
        {
            if(singleton == null)
            {
                singleton = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void SetAnimator(Animator animator)
        {
            playerAnimator = animator;
        }

        public void SetUIController(UIController controller)
        {
            uiController = controller;
        }
    }
}
