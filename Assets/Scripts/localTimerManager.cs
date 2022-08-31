using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localTimerManager : MonoBehaviour
{
    public GameObject localTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupTimer(int maxvalue){
        this.localTimer.GetComponent<Slider>().maxValue = maxvalue;
    }
    
    public void ManageTimer(float value){
        this.localTimer.GetComponent<Slider>().value = value;
    }
}
