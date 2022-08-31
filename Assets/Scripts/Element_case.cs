using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_case : MonoBehaviour
{
    public int howManyP = 0;
    public bool isEmpty = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isEqualtoP(int p_num){
        return p_num==this.howManyP;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="element"){
            this.howManyP = other.gameObject.GetComponent<Elements>().p_num;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="element"){    
            this.howManyP = 0;
            this.isEmpty = true;
        }
    }
}
