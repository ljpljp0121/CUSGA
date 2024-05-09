using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject playerMap;
    public GameObject dogMap;
    void Awake()
    {
        playerMap.SetActive(true);
        dogMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyUp(KeyCode.H))
        {
            if(playerMap.activeSelf)
            {
                playerMap.SetActive(false);
                dogMap.SetActive(true);
            }
            else
            {
                playerMap.SetActive(true);
                dogMap.SetActive(false);
            }
        }
    }
}
