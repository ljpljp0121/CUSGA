using UnityEngine;
using UnityEngine.EventSystems;

public class ListItem : MonoBehaviour, IPointerDownHandler
{
    public GameObject image;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        image.SetActive(true);
    }
}
