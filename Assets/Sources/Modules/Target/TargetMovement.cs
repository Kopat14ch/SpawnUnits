using System.Collections;
using System.Collections.Generic;
using Sources.Modules.Common;
using UnityEngine;

namespace Sources.Modules.Target
{
    internal class TargetMovement : MonoBehaviour
    {
        [SerializeField] private List<Point> _points;

        private const float Speed = 3f;
        private int _currentIndex;
        
        private Coroutine _goPointWork;

        private void Awake()
        {
            if (_points.Count <= 0)
                return;

            _currentIndex = 0;
            
            _goPointWork = StartCoroutine(GoPoint(_points[_currentIndex]));
        }

        private void StartNewPoint(Point point)
        {
            if (_goPointWork != null)
                StopCoroutine(_goPointWork);

            _goPointWork = StartCoroutine(GoPoint(point));
        }

        private IEnumerator GoPoint(Point point)
        {
            while (transform.position != point.CurrentPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, point.CurrentPosition, Speed * Time.deltaTime);
                
                yield return null;
            }
            _currentIndex++;

            _currentIndex %= _points.Count;

            StartNewPoint(_points[_currentIndex]);
        }
    }
}