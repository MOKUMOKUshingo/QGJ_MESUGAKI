using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public int p_num;
    public Vector3 home_Position;
    private Vector3 screenPoint;
    private Vector3 offset;

    public Sprite[] elementTypeSprites; 
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag=="element_case"){
            if(!Input.GetMouseButton(0)){
                transform.position = other.transform.position;
            }
        }else if(other.gameObject.tag=="element"){
                transform.position = this.home_Position;
        }
    }    
    

    // 追加
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
    }
    // 追加
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    void OnMouseUp()
    {
        if(transform.position.x > -8.0&&transform.position.x < 2.0&&-4.0<transform.position.y && transform.position.y<2.0){
            
        }else{
            transform.position = this.home_Position;
        }
    }

    public void SelectingElement(int p_num){
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.p_num = p_num;
        this.spriteRenderer.sprite = elementTypeSprites[p_num-1];
        
    }
}
