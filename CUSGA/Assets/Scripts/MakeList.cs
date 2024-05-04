using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MakeList : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject listImage;
    public void OnPointerEnter(PointerEventData eventData)
    {
        listImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        listImage.SetActive(false);
    }
}
