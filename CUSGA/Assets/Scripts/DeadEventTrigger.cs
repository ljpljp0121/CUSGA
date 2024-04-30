using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEventTrigger : MonoBehaviour
{
    public float T;
    public Player player;
    public float duration;
    void Start()
    {
        
    }

    public void EventTrigger()
    {
        player.stateMachine.ChangeState(player.idleState);
    }

}
