using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
namespace Missiles
{
    public class TankEnemy : Enemy
    {
        public GameObject[] pathPoints;
        public GameObject explotionPrefabs;
        private int selectedPoint;
        private NavMeshAgent _tankNavMesh;
        void Start()
        {
            _tankNavMesh = GetComponent<NavMeshAgent>();
            pathPoints = GameObject.FindGameObjectsWithTag("PathPoint");
            selectedPoint = Random.Range(0, pathPoints.Length);

            if (_tankNavMesh)
            {
                _tankNavMesh.avoidancePriority = Random.Range(1, 100);
                _tankNavMesh.speed = speed;
                if (pathPoints.Length > 0)
                {
                    _tankNavMesh.SetDestination(pathPoints[selectedPoint].transform.position);
                }
            }
        }

        void FixedUpdate()
        {
            Move();
        }

        public override void Move()
        {
            if (!dead && _tankNavMesh && _tankNavMesh.remainingDistance <= 1)
            {
                if (selectedPoint < pathPoints.Length)
                {
                    _tankNavMesh.SetDestination(pathPoints[selectedPoint].transform.position);
                    selectedPoint += 1;
                }
                else
                {
                    selectedPoint = 0;
                }

            }
        }
        public override void Dead()
        {
            if (!dead)
            {
                dead = true;
                if (explotionPrefabs)
                {
                    Instantiate(explotionPrefabs, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}

