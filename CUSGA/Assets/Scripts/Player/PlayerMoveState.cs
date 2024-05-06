public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.particleSystem.Play();
        player.audioSource.Play();
    }

    public override void Exit()
    {
        base.Exit();
        player.particleSystem.Stop();
        player.audioSource.Stop();
    }

    public override void Update()
    {
        base.Update();

        if(!player.canMove)
            stateMachine.ChangeState(player.idleState);

        player.SetVelocity(xInput * player.moveSpeed , rb.velocity.y );

        if (xInput == 0 )//|| player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
