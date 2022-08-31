using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSetter : MonoBehaviour
{
    public GameObject ElementPrefab;
    private Transform parent;
    public int[] order;

    private void Start() {
        //ChildDestroy(this.gameObject);
        this.parent = this.transform;
        GenerateElements(this.order);
    }
    
    public void GenerateElements(int[] order){
        for(var i = 0;i < order.Length;i++){
            GameObject  element_instance=  Instantiate(ElementPrefab, new Vector3(-6.5f + 1.0f*i,-3.2f,0f), Quaternion.identity, this.parent) as GameObject;
            element_instance.GetComponent<Elements>().enabled = true;
            element_instance.GetComponent<Elements>().SelectingElement(order[i]);
        }
    }

    public void ChildDestroy(GameObject parent) {
        //parentには削除したい子オブジェクトたちの親オブジェクトを指定する
        //子供オブジェクトを全部消す
        var uiobj = GetChildren(parent);
        foreach (GameObject child in uiobj) {
            Destroy(child);
        }
    }
    private GameObject[] GetChildren(GameObject parent) {
        // 見つからなかったらreturn
        if (parent == null) return null;
        // 子のTransform[]を取り出す
        var transforms = parent.GetComponentsInChildren<Transform>();
        // 使いやすいようにtransformsからgameObjectを取り出す
        List<GameObject> gameObjects = new List<GameObject>();
        foreach(Transform t in transforms){
            gameObjects.Add(t.gameObject);
        }
        // 配列に変換してreturn
        return gameObjects.ToArray();
    }
}