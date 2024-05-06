using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MakeList : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject listImage;
    public GameObject listItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        listItem.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        listImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        listImage.SetActive(false);
    }
}
