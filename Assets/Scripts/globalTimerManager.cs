using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalTimerManager : MonoBehaviour
{
    public GameObject globalTimer;
    private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupTimer(int maxvalue){
        this.maxValue = maxvalue;
    }
    
    public void ManageTimer(float value){
        this.globalTimer.GetComponent<Text>().text = "のこり "+ Mathf.Round(maxValue-value).ToString() + "びょう";
    }
}
