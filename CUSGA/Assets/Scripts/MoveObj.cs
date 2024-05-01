using UnityEditor.Rendering;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private int num = 0;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if(Vector2.Distance(transform.position, targets[num].position) < 0.1f)
        {
            num++;
            if(num >= targets.Length)
            {
                num = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targets[num].position, speed * Time.deltaTime);
    }
}
