using System.Collections.Generic;
using Sources.Modules.Common;
using Sources.Modules.Enemy;
using Sources.Modules.Target;
using UnityEngine;

namespace Sources.Game.Scripts
{
    [RequireComponent(typeof(EnemyFactory))]
    public class GameRoot : MonoBehaviour
    { 
        [SerializeField] private List<TargetPosition> _targetPositions;
        [SerializeField] private List<Point> _points;
        
        private EnemyFactory _enemyFactory;
        private void Awake() 
        {
           _enemyFactory = GetComponent<EnemyFactory>();

           for (int i = 0; i < _targetPositions.Count; i++)
           {
               _enemyFactory.CreateEnemy(_points[Random.Range(0, _points.Count)], _targetPositions[i]);
           }
           
           
        } 
    }
}
