using Sources.Modules.Common;
using Sources.Modules.Target;
using UnityEngine;

namespace Sources.Modules.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GoTarget _goTargetPrefab;

        private GoTarget _goTarget;
        
        public void CreateEnemy(Point spawnPoint, TargetPosition targetPosition)
        {
            _goTarget = Instantiate(_goTargetPrefab, spawnPoint.CurrentPosition, Quaternion.identity);
            
            _goTarget.SetTargetPosition(targetPosition);
        }
    }
}
