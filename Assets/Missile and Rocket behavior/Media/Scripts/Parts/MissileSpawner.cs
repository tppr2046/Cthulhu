/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	MissileSpawner.cs  				   *
 *                                                     *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class MissileSpawner : MonoBehaviour
    {

        public enum AxisToRotate { AroundX, AroundY, AroundZ, noRotate }
        [Header("Variables")]
        [Tooltip("This is the projectile to spawn.")]
        public GameObject missile;
        [Tooltip("This is the projectile number to spawn.")]
        public int number;
        [Tooltip("This is the spawn time per tic.")]
        public float spawnTicTime = 0.1f;
        [Tooltip("This is the rotation speed for the spawner.")]
        public float rotationSpeed = 10.0f;

        [Tooltip("This is the axis to rotate the spawner.")]
        public AxisToRotate way = AxisToRotate.noRotate;

        [Tooltip("This is prefabs if have a launch effect.")]
        public GameObject launchExplotion;

        [HideInInspector]
        public int ricochetNumber = 0;      //this is from ricochet missile use

        //private vars
        private GameObject newMissile;

        void Start()
        {
            InvokeRepeating("SpawnMisile", 0, spawnTicTime);
        }
        void SpawnMisile()
        {
            switch (way)
            {
                case AxisToRotate.AroundX:
                    transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed, 10);
                    break;
                case AxisToRotate.AroundY:
                    transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, 10);
                    break;
                case AxisToRotate.AroundZ:
                    transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed, 10);
                    break;
                case AxisToRotate.noRotate:
                    break;
            }
            if (number > 0)
            {
                if (launchExplotion) { Instantiate(launchExplotion, transform.position, transform.rotation); }

                newMissile = Instantiate(missile, transform.position, transform.rotation);
                //if ricochet
                if (newMissile.GetComponent<Ricochet>()) { newMissile.GetComponent<Ricochet>().numberOfJump = ricochetNumber; }
                number--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
