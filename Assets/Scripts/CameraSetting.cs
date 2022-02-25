using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task.TPSControls
{
    [CreateAssetMenu(fileName = "CameraSetting", menuName = "Setting/CameraSetting", order = 1)]
    public class CameraSetting : ScriptableObject
    {
        public float sensitivity;
        public float distance;
        public float angleMin;
        public float angleMax;
    }
}
