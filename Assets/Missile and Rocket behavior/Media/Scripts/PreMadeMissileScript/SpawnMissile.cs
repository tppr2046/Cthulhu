/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	SpawnMissile.cs  			       *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class SpawnMissile : MissileScript
    {
        [Header("Specific variables")]
        [Tooltip("The object to spawn")]
        public GameObject[] spawn;

        [Tooltip("The rotation for the spawn")]
        public Vector3 rotation;

        private Vector3 m_Position;

        public override void MissileContact()
        {
            activate = true;
            if (explosionPrefab)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            Spawn();
            GameObject.Destroy(gameObject);
        }

        void Spawn()
        {
            m_Position = transform.position;
            activate = true;
            for (int i = 0; i < spawn.Length; i++)
            {
                if (spawn[i])
                {
                    Instantiate(spawn[i], m_Position, Quaternion.Euler(rotation));
                }
            }
        }
    }
}
