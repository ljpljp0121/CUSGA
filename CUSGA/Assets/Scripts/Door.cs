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

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    private Animator animator;

    public GameObject k;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canuse&&Input.GetKeyDown(KeyCode.K)&&hasKey)
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
            }
            else
                Debug.Log("此门无法使用");
        }
    }

    public GameObject black;
    public void UseDoor()
    {
        black.SetActive(true);
        if (hasKey && npcType == NpcType.Player)
            k.SetActive(false);
        if (backDoor.name == "DoorEnter3")
        {
            Player.instance.SetDogMap();
        }
        else
        {
            Player.instance.SetPlayerMap();
        }
        if(gameObject.name == "DoorOut3")
        {
            SoundManager.instance.audioSource.Stop();
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
        Debug.Log(GetComponentInChildren<SpriteRenderer>().sprite);
        if (other.gameObject.CompareTag("Player"))
        {
            canuse = true;
            if(hasKey&&npcType == NpcType.Player)
                k.SetActive(true);
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

                    Invoke("ChangeType", 0.24f);
                }
            }
        }      
    }

    private void ChangeType()
    {
        if (npcType == NpcType.one)
        {
            npcType = NpcType.two;
            two.SetActive(true);
            Destroy(one);
        }
        else if (npcType == NpcType.two)
        {
            npcType = NpcType.three;
            three.SetActive(true);
            Destroy(two);
        }
        else if (npcType == NpcType.three)
        {
            npcType = NpcType.four;
            four.SetActive(true);
            Destroy(three);
        }
        else if (npcType == NpcType.four)
        {
            npcType = NpcType.Player;
            Destroy(four);
        }

        Debug.Log(GetComponentInChildren<SpriteRenderer>().sprite);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canuse = false;

            if (hasKey && npcType == NpcType.Player)
                k.SetActive(false);
        }

        audioSource.clip = null;
    }
}
