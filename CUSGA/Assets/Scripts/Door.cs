using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public enum NpcType
{
    Player,
    one,
    two,
    three,
    four
}

public class Door : MonoBehaviour
{
    public bool hasKey;
    public bool destroyNPC;
    [SerializeField] private Transform backDoor;//目的地
    private bool canuse;

    public CinemachineConfiner2D confiner;
    public PolygonCollider2D bounds;
    public NpcType npcType = NpcType.Player;
    private AudioSource audioSource;

    public GameObject 过场动画;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite player;

    private Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canuse&&Input.GetKeyDown(KeyCode.W)&&hasKey)
        {
            if (backDoor != null&&npcType == NpcType.Player)
            {
                if (audioSource.clip == null)
                {
                    int soundnum = Random.Range(10, 12);
                    audioSource.clip = SoundManager.instance.SoundList[soundnum];
                    audioSource.Play();
                }

                //动画
                animator.SetTrigger("UseDoor");

                
                if (backDoor.name == "DoorOut1")
                {
                    Player.instance.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "第二关";
                }       
            }
            else
                Debug.Log("此门无法使用");
        }
    }

    public void UseDoor()
    {
        if (backDoor.name == "DoorOut2")
        {
            Player.instance.SetDogMap();
        }
        else
        {
            Player.instance.SetPlayerMap();
        }
        Player.instance.transform.position = backDoor.position;
        if (bounds != null)
        {
            confiner.m_BoundingShape2D = bounds;
        }
    }

    public void Play()
    {
        if (过场动画 != null)
        {
            过场动画.SetActive(true);
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
                if (other.GetComponent<NpcFollowMono>() !=null&& other.GetComponent<NpcFollowMono>().layerint == 9 && other.GetComponent<NpcFollowMono>().npctype == npcType)
                {
                    if (audioSource.clip == null)
                    {
                        int soundnum = Random.Range(10, 12);
                        audioSource.clip = SoundManager.instance.SoundList[soundnum];
                        audioSource.Play();
                    }

                    Destroy(other.gameObject);

                    if(npcType == NpcType.one)
                    {
                        npcType = NpcType.two;
                        GetComponent<SpriteRenderer>().sprite = two;
                    }
                    else if(npcType == NpcType.two)
                    {
                        npcType = NpcType.three;
                        GetComponent<SpriteRenderer>().sprite = three;
                    }
                    else if(npcType == NpcType.three)
                    {
                        npcType = NpcType.four;
                        GetComponent<SpriteRenderer>().sprite = four;
                    }
                    else if(npcType == NpcType.four)
                    {
                        npcType = NpcType.Player;
                        GetComponent<SpriteRenderer>().sprite = player;
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

        audioSource.clip = null;
    }
}
