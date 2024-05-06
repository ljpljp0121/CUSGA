using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject startImage;
    public GameObject allImage;
    public GameObject startVedio;
    public bool isOver;

    public void OnPointerDown(PointerEventData eventData)
    {
        startVedio.SetActive(true);
        Invoke("Off", 0.2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isOver)
            startImage.SetActive(true);
        else
            Application.Quit();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startImage.SetActive(false);
    }

    private void Off()
    {
        allImage.SetActive(false);
    }
}
