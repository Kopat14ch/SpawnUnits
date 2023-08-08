using UnityEngine;

namespace Sources.Modules.Common
{
    public class Point : MonoBehaviour
    {
        public Vector3 CurrentPosition => transform.position;
    }
}