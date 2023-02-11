/*******************************************************
 * 													   *
 * Asset:		 	Go for it   	        		   *
 * Script:		 	RacemeMissile.cs  			       *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class RacemeMissile : MissileScript
    {
        [Header("Specific variables")]
        [Tooltip("The other missiles to launch.")]
        public GameObject missile;
        [Tooltip("The other missiles number.")]
        public int numberToSpaw = 10;
        [Range(1f, 10f)]
        [Tooltip("The projectile time to launch other missiles.")]
        public float activateOthersTime = 1;


        private Vector3 m_Position;
        private Quaternion m_Rotation;
        // Use this for initialization
        void Start()
        {
            UseGravity(false);
            currentSpeed = startSpeed;
            offSet = 0;
        }
        private void Update()
        {
            activateOthersTime -= Time.deltaTime;
            if (activateOthersTime <= 0 && !activate)
            {
                SpawnOthers();
            }
        }

        void SpawnOthers()
        {
            m_Position = transform.position;
            m_Rotation = transform.rotation;
            activate = true;
            for (int i = 0; i < numberToSpaw; i++)
            {
                Instantiate(missile, m_Position + Random.insideUnitSphere * 0.2f, m_Rotation * Random.rotationUniform);
            }
            MissileContact();
        }
    }
}
