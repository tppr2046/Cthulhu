/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	Javelin_Missile.cs  			   *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{

    public class TurretMissile : MissileScript
    {

        [Header("Specific variables")]
        [Range(1f, 5f)]
        [Tooltip("The projectile inactive time in air before activate and go for the target.")]
        public float timeInactive = 0;          //inactive time in air

        //private variables
        private float temporalTime = 0;
        // Use this for initialization
        void Start()
        {
            UseGravity(false);
            currentSpeed = startSpeed;
            timeToSetTarget = 0;
            offSet = 0;
            GetTarget();
        }



        void GetTarget()
        {
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

            addTarget = true;
        }


        void FixedUpdate()
        {

            EndLifeByTime();                    //destroy the projectile  if the time life is over


            if (currentSpeed < 0)
            {
                turnSpeed = 50;
                currentSpeed = 0;
                UseGravity(true);
            }
            else if (addTarget)
            {
                temporalTime += Time.deltaTime;
            }
            else
                Accelerate(-20);

            if (temporalTime > timeInactive)
            {
                UseGravity(false);
                if (temporalTime > timeInactive + 1.5f)
                    RemoveForces(true);
                if (temporalTime > timeInactive + 1.6f)
                    RemoveForces(false);
                turnSpeed = 180;
                Accelerate(80);             //Accelerate speed not more than maxima speed
            }

            //            PersuitTarget3D();                  //follow the target if exist,if not going ahead
                      PersuitFixPoint();
        }
    }
}