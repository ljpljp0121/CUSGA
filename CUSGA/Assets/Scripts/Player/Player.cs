using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Windows;

public class Player : Entity
{
    public static bool istwo;
    public GameObject Light2D;
    public Transform AliveBackgroundPosition;
    public Animator AliveBackgroundAnim;

    public DialogueSystem dialog;
    private string aliveDialog = "主角：谢谢你米洛，让我们再来一次!";
    private bool firstDie;

    [HideInInspector]public bool canMove;

    public FadeInOut fadeInOut;

    public MapManager mapManager;

    public PhysicsMaterial2D zero;
    public PhysicsMaterial2D max;

    public static Player instance;
    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;
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
    public PlayerAliveState aliveState { get; private set; }

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
        aliveState = new PlayerAliveState(this, stateMachine, "Alive");

        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

        canMove = false;
        firstDie = true;
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

        if (!canMove)
        {
            SetZeroVelocity(rb.velocity.y);
            return;
        }

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
        fadeInOut.StartFadeInOut();
        stateMachine.ChangeState(deadState);
        SetPlayerMap();

        if(!firstDie)
        {
            dialog.DialogueText.Clear();
            dialog.DialogueText.Add(aliveDialog);
        }

        firstDie = false;
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
