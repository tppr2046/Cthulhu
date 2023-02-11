/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	Carrier.cs  		    		   *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class Carrier : MissileScript
    {
        [Header("Specific variables")]
        [Tooltip("Time to start spawn.")]
        public float startSpawn = 1;
        [Tooltip("Time betwen spawn.")]
        public float spawnTimeTic = 1;
        [Tooltip("Time to end spawn after the spawn start.")]
        public float spawnCarrierTime = 5;
        [Tooltip("Spawn the next missile in mirror rotation.")]
        public bool mirror = false;
        [Tooltip("The object to spawn.")]
        public GameObject carrierSpawn;
        [Tooltip("The angle to spawn the object")]
        public Vector3 spawAngle;


        private float timeTemp;

        private void Awake()
        {
            spawnCarrierTime += startSpawn;
            timeTemp = spawnTimeTic;
        }
        public void Update()
        {
            if (timeTemp >= 0)
            {
                timeTemp -= Time.fixedDeltaTime;
            }
            if (startSpawn <= time && time <= spawnCarrierTime)
            {
                if (!activate && timeTemp <= 0)
                {
                    activate = true;
                    CarrierSpawn();
                }
            }
        }
        void CarrierSpawn()
        {
            timeTemp = spawnTimeTic;
            if (carrierSpawn)
            {
                Instantiate(carrierSpawn, transform.position, Quaternion.Euler(spawAngle));
                if (mirror)
                {
                    spawAngle = spawAngle * -1;
                }
            }
            activate = false;
        }
    }
}
