using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool destroyNPC;
    [SerializeField] private Transform backDoor;//目的地
    private bool canuse;

    public CinemachineConfiner2D confiner;
    public PolygonCollider2D bounds;
    public bool 第二关光照;

    private void Update()
    {
        if (canuse&&Input.GetKeyDown(KeyCode.W))
        {
            if (backDoor != null)
            {
                Player.instance.transform.position = backDoor.position;

                if (bounds != null)
                {
                    confiner.m_BoundingShape2D = bounds;
                }
                if(第二关光照)
                {
                    Player.instance.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "第二关";
                }
            }
            else
                Debug.Log("此门无法使用");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.gameObject.CompareTag("Player"))
        {
            canuse = true;
        }
        else
        {
            if (destroyNPC)
            {
                if (other.gameObject.layer == 9)
                {
                    Debug.Log("Npc");
                    Destroy(other.gameObject);
                }
            }
        }      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canuse = false;
        }
    }
}
