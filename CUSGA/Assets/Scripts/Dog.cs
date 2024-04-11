using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Animator animator;
    public Transform player;


    void Update()
    {

        if(Mathf.Abs(transform.position.x - Player.instance.transform.position.x) > 0.5f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
}
