// (c) Copyright HutongGames, LLC 2010-2022. All rights reserved.
// THIS CONTENT IS AUTOMATICALLY GENERATED. __PLAYMAKER_EVENT_PROXY__
// this script was generated by the 'PlayMaker Event Proxy Wizard'. You can edit this script directly now, but prefer using the wizard if you are not sure.

using UnityEngine;
using HutongGames.PlayMaker.Ecosystem.Utils;
using HutongGames.PlayMaker;

namespace com.holded
{
	public class HoldedProxy : PlayMakerEventProxy {

		[Button("Holded","Test : Holded")] public bool _;
		public void Holded()
		{
			if (debug || !Application.isPlaying)
			{
				Debug.Log("HoldedProxy : Holded()");
			}

            

			base.SendPlayMakerEvent();
		}
	}
}