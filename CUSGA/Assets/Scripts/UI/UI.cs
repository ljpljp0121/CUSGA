using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(0);//�л�����������ǰ����
        //SceneManager.LoadScene(0, LoadSceneMode.Additive);//�л�����������ǰ����
    }
    public void Scene2()
    {
        SceneManager.LoadScene(1);//�л�����������ǰ����
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//�л�����������ǰ����
    }
    public void Scene3()
    {
        SceneManager.LoadScene(2);//�л�����������ǰ����
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//�л�����������ǰ����
    }
    public void Scene4()
    {
        SceneManager.LoadScene(3);//�л�����������ǰ����
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//�л�����������ǰ����
    }
    public void Scene5()
    {
        SceneManager.LoadScene(4);//�л�����������ǰ����
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);//�л�����������ǰ����
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
