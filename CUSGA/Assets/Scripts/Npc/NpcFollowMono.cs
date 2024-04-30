using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollowMono : MonoBehaviour
{
    public NpcType npctype;

    public int layerint;
    /// <summary>
    /// 跟随的点
    /// </summary>
    private Transform target;
    Transform self;

    /// <summary>
    /// 跟随的延迟时间，npc位置为delay秒前玩家的位置
    /// </summary>
    [SerializeField] float delay;

    /// <summary>
    /// target位置缓存队列
    /// </summary>
    public readonly Queue<Vector2> playerPositionsCache=new();

    /// <summary>
    /// 开始跟随的时间点
    /// </summary>
    float startFollowTime;

    /// <summary>
    /// 是否跟随状态
    /// </summary>
    bool following;

    /// <summary>
    /// 是否进行跟随的接口
    /// </summary>
    public bool Following
    {
        get => following;
        set
        {
            following = value;

            if (following) //开始跟随，计算跟随开始的时间点
            {
                startFollowTime = Time.time + delay;
            }

            else   //如果不跟随，清空缓存队列
            {
                playerPositionsCache.Clear();
            }
        }
    }

    private void Start()
    {
        target = Player.instance.transform;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.layer = layerint;
            playerPositionsCache.Clear();
            Following = true;
        }
    }

    private void Awake()
    {
        self = transform;
    }
    private void Update()
    {
        RecordTargetPosition(target.position);
        //满足跟随的延迟
        if (following&& Time.time > startFollowTime)
        {
            Follow();
        }

        if(transform.position.x < Player.instance.transform.position.x+0.5f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (transform.position.x > Player.instance.transform.position.x - 0.5f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    /// <summary>
    /// 跟随逻辑
    /// </summary>
    private void Follow()
    {
        self.position = playerPositionsCache.Dequeue();
    }

    /// <summary>
    ///  记录目标点位置到缓存队列
    /// </summary>
    private void RecordTargetPosition(Vector2 targetPosition)
    {
        playerPositionsCache.Enqueue(targetPosition);
    }

}
