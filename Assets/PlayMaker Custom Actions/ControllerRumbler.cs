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

        
        [CheckForComponent(typeof(PlayerInput))]
        public FsmGameObject InputObject;

        private PlayerInput _playerInput;

        public override void OnEnter()
        {
            rumbleDurration = Time.time + rDuration.Value;
            _playerInput = InputObject.Value.GetComponent<PlayerInput>();
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
            var gamepad = GetGamepad();
            float leftS = leftSpeed.Value;
            float rightS = rightSpeed.Value;
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(leftS, rightS);
            }

        }




        private void StopRumble()
        {
            var gamepad = GetGamepad();
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0, 0);
            }
        }


        private Gamepad GetGamepad()
        {
            return Gamepad.all.FirstOrDefault(g => _playerInput.devices.Any(d => d.deviceId == g.deviceId));
        }

    }
}
