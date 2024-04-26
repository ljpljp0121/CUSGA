using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public enum NpcType
{
    None,
    one,
    two,
    three,
    four
}

public class Door : MonoBehaviour
{
    public bool destroyNPC;
    [SerializeField] private Transform backDoor;//目的地
    private bool canuse;

    public CinemachineConfiner2D confiner;
    public PolygonCollider2D bounds;
    public NpcType npcType = NpcType.one;

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
                if(backDoor.name == "DoorOut1")
                {
                    Player.instance.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "第二关";
                }
                //第二关出口门在DogMap地形上。第三关入口门在PlayerMap地形上。所以需要改变地图

                if (backDoor.name == "DoorEnter3")
                {
                    Player.instance.SetDogMap();
                }
            }
            else
                Debug.Log("此门无法使用");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            canuse = true;
        }
        else
        {
            if (destroyNPC)
            {
                if (other.GetComponent<NpcFollowMono>().layerint == 9 && other.GetComponent<NpcFollowMono>().npctype == npcType)
                {
                    Destroy(other.gameObject);

                    if(npcType == NpcType.one)
                    {
                        npcType = NpcType.two;
                    }
                    else if(npcType == NpcType.two)
                    {
                        npcType = NpcType.three;
                    }
                    else if(npcType == NpcType.three)
                    {
                        npcType = NpcType.four;
                    }
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
