using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色死亡后淡入淡出
/// </summary>
public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    [Tooltip("淡入淡出时间")]
    public float fadeSpeed;
    [Tooltip("淡入淡出之间黑屏持续时间")]
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
