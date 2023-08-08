using System.Collections;
using Sources.Modules.Target;
using UnityEngine;

namespace Sources.Modules.Enemy
{
    internal class GoTarget : MonoBehaviour
    {
        private const float Speed = 1.5f;

        private TargetPosition _targetPosition;
        private Coroutine _goWork;

        public void SetTargetPosition(TargetPosition targetPosition)
        {
            if (_goWork != null)
                StopCoroutine(_goWork);
            
            _targetPosition = targetPosition;
            
            TryGo();
        }

        private void TryGo()
        {
            if (_goWork == null)
                _goWork = StartCoroutine(Go());
        }

        private IEnumerator Go()
        {
            while (transform.position != _targetPosition.CurrentPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition.CurrentPosition, Speed * Time.deltaTime);
               
                yield return null;
            }
        }
    }
}
