using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayManager : MonoBehaviour
{
    public void RequestSceneChangeTo(int SceneIndex)
    {
        if(0<=SceneIndex&&SceneIndex<SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(SceneIndex);
        }else{
            Debug.LogError("Invalid SceneIndex");
        }
    }
}
