using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class HintTrigger : MonoBehaviour
{
    public string EventName;

    void Hint()
    {

        foreach (PlayMakerFSM _fsm in this.GetComponents<PlayMakerFSM>())
        {
            _fsm.SendEvent(EventName);
        }

    }
}
