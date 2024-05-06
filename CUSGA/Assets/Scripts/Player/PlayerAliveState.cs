using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerState
{
    Vector3 targetPosition;
    float speed = 0.4f;
    public PlayerAliveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.transform.position = player.back.transform.position;
        player.AliveBackgroundPosition.position = player.transform.position;
        player.AliveBackgroundAnim.SetBool("Alive", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.AliveBackgroundAnim.SetBool("Alive", false);
        player.SetVelocity(0.01f, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();
    }
}
