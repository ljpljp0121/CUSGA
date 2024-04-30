using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollowMono : MonoBehaviour
{
    public NpcType npctype;

    public int layerint;
    /// <summary>
    /// ����ĵ�
    /// </summary>
    private Transform target;
    Transform self;

    /// <summary>
    /// ������ӳ�ʱ�䣬npcλ��Ϊdelay��ǰ��ҵ�λ��
    /// </summary>
    [SerializeField] float delay;

    /// <summary>
    /// targetλ�û������
    /// </summary>
    public readonly Queue<Vector2> playerPositionsCache=new();

    /// <summary>
    /// ��ʼ�����ʱ���
    /// </summary>
    float startFollowTime;

    /// <summary>
    /// �Ƿ����״̬
    /// </summary>
    bool following;

    /// <summary>
    /// �Ƿ���и���Ľӿ�
    /// </summary>
    public bool Following
    {
        get => following;
        set
        {
            following = value;

            if (following) //��ʼ���棬������濪ʼ��ʱ���
            {
                startFollowTime = Time.time + delay;
            }

            else   //��������棬��ջ������
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
        //���������ӳ�
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
    /// �����߼�
    /// </summary>
    private void Follow()
    {
        self.position = playerPositionsCache.Dequeue();
    }

    /// <summary>
    ///  ��¼Ŀ���λ�õ��������
    /// </summary>
    private void RecordTargetPosition(Vector2 targetPosition)
    {
        playerPositionsCache.Enqueue(targetPosition);
    }

}
