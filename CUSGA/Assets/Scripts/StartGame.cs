using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public GameObject startImage;
    public GameObject allImage;
    public GameObject startVedio;

    public void OnPointerDown(PointerEventData eventData)
    {
        startVedio.SetActive(true);
        allImage.SetActive(false);
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
