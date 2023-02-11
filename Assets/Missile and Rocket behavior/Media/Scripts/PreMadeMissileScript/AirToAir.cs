/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	AirToAir.cs    				       *
 *  												   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{

    public class AirToAir : MissileScript
    {

        [Header("Specific variables")]
        [Tooltip("This is the time the projectile waits to activate after launching.")]
        public float activateMissile = 0;           //the time this projectile  waits to activate after launching.

        [Tooltip("This is the projectile fall speed.")]
        public float fallSpeed = 10;                //fall speed for the missile.

        // Use this for initialization
        void Start()
        {
            currentSpeed = startSpeed;
            UseGravity(false);
        }

        void FixedUpdate()
        {

            EndLifeByTime();                   //destroy the projectile  if the time life is over

            switch (typeOfTarget)
            {
                case TargetType.targetFerstEnemy:
                    TargetEnemy();
                    break;
                case TargetType.targetNearestEnemy:
                    TargetNearestEnemy(minDistance, maxDistance);
                    break;
                case TargetType.targetRandomEnemy:
                    TargetRandomEnemy();
                    break;
                default:
                    break;
            }

            if (activateMissile < time)
            {
                offSet = 2;
                PersuitTarget3D();              //follow the target if exist,if not going ahead	
                Accelerate(20);
            }
            else
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);     //make the proyectile fall.
        }
    }
}