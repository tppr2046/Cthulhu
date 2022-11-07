using UnityEngine;
using XInputDotNetPure; // Required in C#



namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Rumbles Controller Every Frame for XInput Gamepad")]

	[UIHint(UIHint.Variable)]

	public class XInputRumble : FsmStateAction
	{
#if	UNITY_STANDALONE_WIN
		PlayerIndex playerIndex;
		public FsmBool enableRumble;
		public FsmInt gamepad;
		public FsmFloat leftMotor;
		public FsmFloat rightMotor;
		int deviceIndex;

	
		void DoXInputRumble()
		{
			if (enableRumble.Value)
			{
				deviceIndex = gamepad.Value;
				PlayerIndex playerIndex = (PlayerIndex)deviceIndex;
				GamePad.SetVibration(playerIndex, leftMotor.Value, rightMotor.Value);
			}
			else
			{
				deviceIndex = gamepad.Value;
				PlayerIndex playerIndex = (PlayerIndex)deviceIndex;
				GamePad.SetVibration(playerIndex, 0, 0);
			}

		}


	

		public override void OnUpdate()
		{
			DoXInputRumble();
		}

		public override void OnExit()
		{
			deviceIndex = gamepad.Value;
			PlayerIndex playerIndex = (PlayerIndex)deviceIndex;
			GamePad.SetVibration(playerIndex, 0, 0);
		}

#endif
	}
}
