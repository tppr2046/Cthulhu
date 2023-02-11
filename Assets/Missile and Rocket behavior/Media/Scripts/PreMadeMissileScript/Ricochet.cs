/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	Ricochet.cs      			       *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class Ricochet : MissileScript
    {
        [Header("Specific variables")]
        [Tooltip("This is the number of jump.")]
        public int numberOfJump;

        [Tooltip("This is the spawner.")]
        public GameObject missileSpawner;

        void InstOther()
        {
            if (missileSpawner)
            {
                missileSpawner=Instantiate(missileSpawner, transform.position, Quaternion.Euler(260,0,0));
                missileSpawner.GetComponent<MissileSpawner>().ricochetNumber = numberOfJump - 1;
            }
            MissileContact();
        }

        private new void OnTriggerEnter(Collider other)
        {
            if (damageOnTrigger)
            {
                //this avoid duplicate the collision
                if (activate) { return; }
                // if the missile got hit with it's or whit the player, ignore it
                if (tag == "Missile" && other.gameObject.tag == "Missile" || other.gameObject.tag == "Player") { return; }

                if (other.gameObject.GetComponent<HitPoint>() != null)
                {   // if the hit object has the Health script on it, deal damage

                    other.gameObject.GetComponent<HitPoint>().ApplyDamage(damageAmount);
                }
                activate = true;
                if (numberOfJump > 1)
                {
                    InstOther();
                }
                MissileContact();
            }
        }

        // this is used for things that explode on impact and are NOT triggers
        public new void OnCollisionEnter(Collision other)
        {
            if (damageOnCollision)
            {
                //this avoid duplicate the collision
                if (activate) { return; }
                // if the missile got hit with it's or whit the player, ignore it
                if (tag == "Missile" && other.gameObject.tag == "Missile" || other.gameObject.tag == "Player")
                    return;
                // if the hit object has the Enemy_Controller script on it, deal damage
                if (other.gameObject.GetComponent<HitPoint>() != null)
                {
                    other.gameObject.GetComponent<HitPoint>().ApplyDamage(damageAmount);
                }
                activate = true;
                if (numberOfJump > 1)
                {
                    InstOther();
                }
                MissileContact();
            }
        }
    }
}
