using UnityEngine;

public class FireWind : MonoBehaviour
{
    public GameObject fireWind;
    public float intervalTime;
    private float newIntervalTime;
    public float keepTime;
    private float newKeepTime;
    void Start()
    {
        fireWind.SetActive(false);
    }

    void Update()
    {
        newIntervalTime += Time.deltaTime;
        if (newIntervalTime > intervalTime)
        {
            fireWind.SetActive(true);
            newKeepTime += Time.deltaTime;

            if (newKeepTime > keepTime)
            {
                fireWind.SetActive(false);
                newIntervalTime = 0;
                newKeepTime = 0;
            }
        }
    }
}
