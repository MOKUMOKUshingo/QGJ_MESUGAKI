using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solve_Button : MonoBehaviour
{
    public GameObject CalculationManager;
    public GameObject allManager;

    public float _timer;
    [SerializeField]private float scaler;
    private Vector3 _default_scale;

    public GameObject supervisor;

    private void Start() {
        this._default_scale = transform.localScale;
    }
    
    private void OnMouseEnter() {
        this._timer = 0;
    }

    private void OnMouseOver() {
        this._timer += Time.deltaTime;
        float delta_ = Mathf.Sin(_timer*2)*Mathf.Sin(_timer*2)*this.scaler;
        transform.localScale = this._default_scale + new Vector3(delta_, delta_, delta_);
    }
    private void OnMouseExit() {
        transform.localScale= this._default_scale;
    }


    private void OnMouseDown() {
        var allManagerScript = allManager.GetComponent<AllManager>();
        if(allManagerScript.phase == "解答時間"){
            CalculationManager.GetComponent<CalculationManager>().UpdateFields();
            if(CalculationManager.GetComponent<CalculationManager>().Judge()){
                allManagerScript.NextCycle(1);
            }
        }
    }
}
