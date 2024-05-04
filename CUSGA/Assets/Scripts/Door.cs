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
    [SerializeField] private Transform backDoor;//Ŀ�ĵ�
    private bool canuse;

    public CinemachineConfiner2D confiner;
    public PolygonCollider2D bounds;
    public NpcType npcType = NpcType.one;
    private AudioSource audioSource;
    public int BGM;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canuse&&Input.GetKeyDown(KeyCode.W))
        {
            if (backDoor != null)
            {
                if (audioSource.clip == null)
                {
                    int soundnum = Random.Range(10, 12);
                    audioSource.clip = SoundManager.instance.SoundList[soundnum];
                    audioSource.Play();
                }

                Player.instance.transform.position = backDoor.position;
                

                if (bounds != null)
                {
                    confiner.m_BoundingShape2D = bounds;
                }
                if(backDoor.name == "DoorOut1")
                {
                    Player.instance.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "�ڶ���";
                    Player.istwo = true;
                }
                //�ڶ��س�������DogMap�����ϡ��������������PlayerMap�����ϡ�������Ҫ�ı��ͼ

                if (backDoor.name == "DoorEnter3")
                {
                    Player.instance.SetDogMap();
                    Player.istwo = false;
                }

                if (BGM != 0)
                {
                    SoundManager.instance.PlayBGM(BGM);
                }
            }
            else
                Debug.Log("�����޷�ʹ��");
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
