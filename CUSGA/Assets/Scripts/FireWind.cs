using UnityEngine;

public class FireWind : MonoBehaviour
{
    public GameObject fireWind;
    public float intervalTime;
    private float newIntervalTime;
    public float keepTime;
    private float newKeepTime;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        fireWind.SetActive(false);
    }

    void Update()
    {
        newIntervalTime += Time.deltaTime;
        if (newIntervalTime > intervalTime)
        {
            if (audioSource.clip == null&& Vector2.Distance(transform.position,Player.instance.transform.position)<15)
            {
                int soundnum = Random.Range(0, 5);
                audioSource.clip = SoundManager.instance.SoundList[soundnum];
                audioSource.volume = 0.75f;//(Vector2.Distance(transform.position, Player.instance.transform.position)/15);
                audioSource.Play();
            }
            audioSource.volume -= 0.05f / keepTime*Time.deltaTime;

            fireWind.SetActive(true);
            newKeepTime += Time.deltaTime;

            if (newKeepTime > keepTime)
            {
                audioSource.clip = null;
                fireWind.SetActive(false);
                newIntervalTime = 0;
                newKeepTime = 0;
            }
        }
    }
}
