using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class EnemyReadyTrigger : MonoBehaviour
{
    public string EventName;

    void EnemyReady()
    {

        foreach (PlayMakerFSM _fsm in this.GetComponents<PlayMakerFSM>())
        {
            _fsm.SendEvent(EventName);
        }

    }
}
