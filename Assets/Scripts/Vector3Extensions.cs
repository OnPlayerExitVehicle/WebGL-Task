using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task.Extensions
{
    public static class Vector3Extensions
    {
        public static float AngleSigned(this Vector3 n, Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(
                    Vector3.Dot(
                        n, 
                        Vector3.Cross(a, b)),
                        Vector3.Dot(a, b)) 
                    * Mathf.Rad2Deg;
        }
    }
}