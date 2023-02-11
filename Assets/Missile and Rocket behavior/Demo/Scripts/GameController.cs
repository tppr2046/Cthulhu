using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Missiles
{
    public class GameController : MonoBehaviour
    {
        public GameObject enemyTankPrefab;
        public Transform[] spawnPoint;


        public void SpawnEnemyTank()
        {
            if (enemyTankPrefab)
            {
                for (int i = 0; i < 3; i++)
                {
                    int pos = Random.Range(0, spawnPoint.Length);
                    Instantiate(enemyTankPrefab, spawnPoint[pos].position, spawnPoint[pos].rotation);
                }
            }
        }
    }
}
