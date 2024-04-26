using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ�������뵭��
/// </summary>
public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    [Tooltip("���뵭��ʱ��")]
    public float fadeSpeed;
    [Tooltip("���뵭��֮���������ʱ��")]
    public float waitTime;
    void Start()
    {
        canvasGroup.alpha = 0f;
    }

    public void StartFadeInOut()
    {
        StartCoroutine(FadeInOut_());
    }

    private IEnumerator FadeInOut_()
    {
        canvasGroup.alpha = 0f;
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += fadeSpeed * Time.deltaTime;
        }
        yield return new  WaitForSeconds(waitTime);
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
