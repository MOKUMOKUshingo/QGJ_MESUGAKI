using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Drawer : MonoBehaviour
{
    public Sprite[] _Costume; 
    private Image image;
    public GameObject allManager;
    // Start is called before the first frame update
    void Start()
    {
        var allManagerScript = allManager.GetComponent<AllManager>();
        this.image = this.GetComponent<Image>();
        Transforming(allManagerScript.levelOfGirl);
    }


    public void Transforming(int transform_level){
        if(_Costume.Length <= transform_level){
            this.image.sprite = _Costume[_Costume.Length-1];
        }else if(transform_level < 0){
            Transforming(_Costume.Length + transform_level);
        }else{
            Debug.Log(transform_level);
            this.image.sprite = _Costume[transform_level];
        }
        
    }

}
