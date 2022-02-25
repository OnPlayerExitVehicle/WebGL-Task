using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task.TPSControls
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "Setting/MovementSetting", order = 0)]
    public class MovementSetting : ScriptableObject
    {
        public float rotationSpeed;
    }
}
