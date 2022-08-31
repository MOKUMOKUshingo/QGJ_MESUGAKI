using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcular_case : MonoBehaviour
{
    public int whatType=-1;
    public bool isEmpty=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isEqualtoType(int type){
        return type == this.whatType;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="calcular"){
            this.whatType = other.gameObject.GetComponent<Calculars>().calculation_type;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="calcular"){
            this.whatType = -1;
            this.isEmpty = true;
        }
    }
}
