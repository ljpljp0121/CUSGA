using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeadState : PlayerState
{
    private float elapsedTime;
    private float duration = 4;
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        elapsedTime = 0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        float t = elapsedTime / duration;

        Vector3 currentPosition = Vector3.Lerp(player.transform.position, player.back.position, t);
        player.transform.position = currentPosition;
        elapsedTime += Time.deltaTime;
    }
}

