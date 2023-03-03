using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("PlayerInput")]
    [Tooltip("Controller Rumble")]

    public class ControllerRumbler : GamepadActionBase
    {
        [RequiredField]

        [Tooltip("Gamepad index")]
        public FsmInt gamepadIndex;


        [Tooltip("Left Motor Power")]
        public FsmFloat leftSpeed;


        [RequiredField]

        [Tooltip("Right Motor Power")]
        public FsmFloat rightSpeed;

        [RequiredField]

        [Tooltip("Rumble Duration")]
        public FsmFloat rDuration;

        private FsmFloat rumbleDuration;
        private float rumbleDurration;




        public override void OnEnter()
        {
            rumbleDurration = Time.time + rDuration.Value;
        }


        public override void OnUpdate()
        {


            if (Time.time > rumbleDurration)
            {
                StopRumble();
                return;
            }

            RumbleConstant();



        }

        private void RumbleConstant()
        {
            float leftS = leftSpeed.Value;
            float rightS = rightSpeed.Value;
            Gamepad.current.SetMotorSpeeds(leftS, rightS);


        }




        private void StopRumble()
        {
            Gamepad.current.SetMotorSpeeds(0, 0);
        }
    }
}
