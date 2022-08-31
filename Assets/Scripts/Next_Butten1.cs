using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace myUI
{
public class Next_Butten1:MonoBehaviour
{
    
    [SerializeField] private int target_scene;
    GameObject displayManager;
    
    private void Start() {
        this.displayManager = GameObject.Find("DisplayManager");
    }
    
    public void OnClick()
    {
       this.displayManager.GetComponent<DisplayManager>().RequestSceneChangeTo(target_scene);
    }

}

}