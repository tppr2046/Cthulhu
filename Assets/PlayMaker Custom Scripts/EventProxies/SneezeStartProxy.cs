// (c) Copyright HutongGames, LLC 2010-2022. All rights reserved.
// THIS CONTENT IS AUTOMATICALLY GENERATED. __PLAYMAKER_EVENT_PROXY__
// this script was generated by the 'PlayMaker Event Proxy Wizard'. You can edit this script directly now, but prefer using the wizard if you are not sure.

using UnityEngine;
using HutongGames.PlayMaker.Ecosystem.Utils;
using HutongGames.PlayMaker;

namespace com.spine
{
	public class SneezeStartProxy : PlayMakerEventProxy {

		[Button("SneezeStart","Test : SneezeStart")] public bool _;
		public void SneezeStart()
		{
			if (debug || !Application.isPlaying)
			{
				Debug.Log("SneezeStartProxy : SneezeStart()");
			}

            

			base.SendPlayMakerEvent();
		}
	}
}