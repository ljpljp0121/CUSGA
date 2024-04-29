using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class Player : Entity
{
    public FadeInOut fadeInOut;

    public MapManager mapManager;

    public PhysicsMaterial2D zero;
    public PhysicsMaterial2D max;

    public static Player instance;
    public Transform followPoint;
    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;
    public float swordReturnImpact;
    private float defaultMoveSpeed;
    private float defaultJumpForce;

    public Transform back;

    #region State
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDeadState deadState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        deadState = new PlayerDeadState(this, stateMachine, "Die");

        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);

        defaultMoveSpeed = moveSpeed;
        defaultJumpForce = jumpForce;
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

        if (!IsGroundDetected())
            cd.sharedMaterial = zero;
        else
            cd.sharedMaterial = max;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Back"))
        {
            back = collision.transform;
        }
    }

    public override void SlowEntityBy(float _slowPercentage, float _slowDuration)
    {
        moveSpeed = moveSpeed * (1 - _slowPercentage);
        jumpForce = jumpForce * (1 - _slowPercentage);
        anim.speed = anim.speed * (1 - _slowPercentage);

        Invoke("ReturnDefaultSpeed", _slowDuration);
    }

    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();

        moveSpeed = defaultMoveSpeed;
        jumpForce = defaultJumpForce;
    }
   

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public override void Die()
    {
        base.Die();
        Debug.Log("Die");
        fadeInOut.StartFadeInOut();
        stateMachine.ChangeState(deadState);
        SetPlayerMap();

        //stateMachine.ChangeState(deadState);
    }

    public void SetPlayerMap()
    {
        mapManager.playerMap.SetActive(true);
        mapManager.dogMap.SetActive(false);
    }
    
    public void SetDogMap()
    {
        mapManager.playerMap.SetActive(false);
        mapManager.dogMap.SetActive(true);
    }
}
