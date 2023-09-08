using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class JumpStartTrigger : MonoBehaviour
{
    public string EventName;

    void JumpStart()
    {

        foreach (PlayMakerFSM _fsm in this.GetComponents<PlayMakerFSM>())
        {
            _fsm.SendEvent(EventName);
        }

    }
}
