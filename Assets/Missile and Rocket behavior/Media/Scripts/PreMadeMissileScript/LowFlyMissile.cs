/*******************************************************
 * 													   *
 * Asset:		 	Missile and Rocket behavior        *
 * Script:		 	LowFly_Missile.cs  			       *
 * 													   *
 * Page: https://www.facebook.com/NLessStudio/         *
 * 													   *
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{

    public class LowFlyMissile : MissileScript
    {

        [Header("Specific variables.")]
        [Tooltip("This is the projectile fall speed.")]
        public float fallSpeed = 10;                //projectile  fall speed. 
        [Tooltip("LayerMask to determine what is considered ground for the projectile.")]
        public LayerMask whatIsGround;          //layer mask to determine what is considered ground for the projectile.

        [Tooltip("Distance between the projectile and the ground.")]
        public float distanceToGround = 0;      //distance to ground to stop fall for the projectile.


        void Start()
        {
            currentSpeed = startSpeed;
            UseGravity(false);
            offSet = 0;
        }

        void FixedUpdate()
        {

            EndLifeByTime();                    //destroy the projectile  if the time life is over.
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
            
            if (Physics.Linecast(transform.position, transform.position + new Vector3(0, -distanceToGround, 0), whatIsGround))
            {
                Accelerate(accelerationSpeed);
                PersuitTargetZX();              //follow the target in ZX plane if exist,if not going ahead.
            }
            else
            {
                PersuitTargetZX();
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);     //make the proyectile fall.
            }
        }
    }
}