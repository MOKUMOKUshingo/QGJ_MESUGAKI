using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTransformation : MonoBehaviour
{
    public Sprite[] _Costume; 
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = _Costume[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transforming(int transform_level){
        if(_Costume.Length <= transform_level){
            this.spriteRenderer.sprite = _Costume[_Costume.Length-1];
        }else if(transform_level < 0){
            Transforming(_Costume.Length + transform_level);
        }else{
            Debug.Log(transform_level);
            //Debug.Log(_Costume.Length);
            this.spriteRenderer.sprite = _Costume[transform_level];
        }
        
    }

}
