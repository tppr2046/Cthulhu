using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class TurnStartTrigger : MonoBehaviour
{
    public string EventName;

    void TurnStart()
    {

        foreach (PlayMakerFSM _fsm in this.GetComponents<PlayMakerFSM>())
        {
            _fsm.SendEvent(EventName);
        }

    }
}
