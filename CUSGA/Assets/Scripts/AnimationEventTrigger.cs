using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTrigger : MonoBehaviour
{
    public Player player;
    void Start()
    {
        
    }

    public void DeadEventTrigger()
    {
        player.stateMachine.ChangeState(player.aliveState);
    }

    public void AliveEventTrigger()
    {
        player.stateMachine.ChangeState(player.idleState);

        player.dialog.isTriggerd = false;
        player.dialog.isTalkOver = false;
        player.dialog.mouceCount = 0;
        player.dialog.Talk();
    }


}
