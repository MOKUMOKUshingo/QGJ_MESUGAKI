using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgotIt_button : MonoBehaviour
{
    public float _timer;
    private float scaler = 0.15f;
    private Vector3 _default_scale;

    [SerializeField] private int target_scene;
    GameObject displayManager;

    private void Start() {
        this._default_scale = transform.localScale;

        this.displayManager = GameObject.Find("DisplayManager");
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
       this.displayManager.GetComponent<DisplayManager>().RequestSceneChangeTo(target_scene);
    }
}
