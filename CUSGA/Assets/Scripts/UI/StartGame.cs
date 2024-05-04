using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public GameObject startImage;
    public GameObject AllImage;

    public void OnPointerDown(PointerEventData eventData)
    {
       AllImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startImage.SetActive(false);
    }
}
