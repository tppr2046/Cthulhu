/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	MissileScript.cs  				   *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class MissileScript : BaseMissile
    {

        void Start()
        {
            UseGravity(useGravity);
            if (damageOnTrigger)
            {
                GetComponent<Collider>().isTrigger = true;
            }
            offSet = missileStability;
            currentSpeed = startSpeed;
        }
        void FixedUpdate()
        {

            ExplodeByDistance(distanceToExplode);

            EndLifeByTime();                    //destroy the projectile  if the time life is over

            switch (typeOfTarget)               //select the type of target
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

            PersuitTarget3D();                    //follow the target in 3D space if exist,if not go ahead.

            Accelerate(accelerationSpeed);        //Accelerate speed not more than maxima speed or desaccelerate if accel is negative.

        }
    }
}
