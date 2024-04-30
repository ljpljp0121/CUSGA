using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    private NpcFollowMono followMono;

    private void Awake()
    {
        followMono = GetComponent<NpcFollowMono>();
    }

    void Update()
    {
        if (followMono.playerPositionsCache.Peek().y - transform.position.y >0.001f)
        {
            ChangeAnim("Jump");
        }
        else if (transform.position.y - followMono.playerPositionsCache.Peek().y > 0.001f)
        {
            ChangeAnim("Fall");
        }
        else if (followMono.playerPositionsCache.Peek().x != transform.position.x)
        {   
            ChangeAnim("Move");
        }
        else
        {
            ChangeAnim("Idle");
        }
    }

    private void ChangeAnim(string b)
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Fall", false);
        animator.SetBool("Move", false);
        animator.SetBool("Jump", false);
        animator.SetBool(b, true);
    }
}
