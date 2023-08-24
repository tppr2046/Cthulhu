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
        private float rumbleDurationFloat;

        
        [CheckForComponent(typeof(PlayerInput))]
        public FsmGameObject InputObject;

        [Tooltip("Event to send after the specified time.")]
        public FsmEvent finishEvent;

        private PlayerInput _playerInput;
        private bool isRumbling;

        public override void OnEnter()
        {
            if (rumbleDurationFloat <= Time.time + 5)
            {
                rumbleDurationFloat = Time.time + rDuration.Value;
            }else
            {
                rumbleDurationFloat = Time.time + 5;
            }
            _playerInput = InputObject.Value.GetComponent<PlayerInput>();
            isRumbling = false;
        }


        public override void OnUpdate()
        {


            if (Time.time > rumbleDurationFloat)
            {
                StopRumble();
                return;
            }

            if (!isRumbling)
            {
                RumbleConstant();
                isRumbling = true;
            }

        }

        private Gamepad GetGamepad()
        {
            return Gamepad.all.FirstOrDefault(g => _playerInput.devices.Any(d => d.deviceId == g.deviceId));
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
            isRumbling = false;

            Finish();
            if (finishEvent != null)
            {
                Fsm.Event(finishEvent);
            }

        }




    }
}
