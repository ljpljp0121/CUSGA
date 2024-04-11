using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(0);//切换场景后销毁前场景
        //SceneManager.LoadScene(0, LoadSceneMode.Additive);//切换场景后不销毁前场景
    }
    public void Scene2()
    {
        SceneManager.LoadScene(1);//切换场景后销毁前场景
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//切换场景后不销毁前场景
    }
    public void Scene3()
    {
        SceneManager.LoadScene(2);//切换场景后销毁前场景
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//切换场景后不销毁前场景
    }
    public void Scene4()
    {
        SceneManager.LoadScene(3);//切换场景后销毁前场景
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//切换场景后不销毁前场景
    }
    public void Scene5()
    {
        SceneManager.LoadScene(4);//切换场景后销毁前场景
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//切换场景后不销毁前场景
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
