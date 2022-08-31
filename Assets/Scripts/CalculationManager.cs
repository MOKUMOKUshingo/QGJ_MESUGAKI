using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationManager : MonoBehaviour
{  
    public int[] _p_list;
    public int[] _calcular_list;
    //元素の問題作成（模範解答）
    private int[][] _problem;
    private int _correct;
    //自分の解答
    private int[][] _solution = new int[2][];
    private int _answer;
    

    public GameObject[] _element_case;
    public GameObject[] _calcular_case;
    public GameObject _problemCreater;

    public GameObject _girl;

    private GameObject multiply;

    public int[] difficulty = new int[3];

    
    private void Start() {
        multiply = GameObject.Find("multiply");
    }    
    
    public void UpdateFields()
    {

        if(GameObject.Find("Elements_case3")){
            this._element_case[2] = GameObject.Find("Elements_case3");
        }
        if(GameObject.Find("Calcular_case3")){
            this._calcular_case[1] = GameObject.Find("Calcular_case2");
        }
        _p_list = new int[this._element_case.Length];
        for(int i=0; i < this._element_case.Length; i++){
            this._p_list[i] = _element_case[i].GetComponent<Element_case>().howManyP; 
        }
        _calcular_list = new int[this._calcular_case.Length];
        for(var i=0;i < this._calcular_case.Length;i++){
            this._calcular_list[i] = _calcular_case[i].GetComponent<Calcular_case>().whatType;
        }
        _problemCreater.GetComponent<problem_creater>().QuestionCreater(difficulty[0], difficulty[1]);
        this._correct = _problemCreater.GetComponent<problem_creater>()._answer;
        this._problem = _problemCreater.GetComponent<problem_creater>()._problem;

        this._solution[0] = this._p_list;
        this._solution[1] = this._calcular_list;
        this._answer = _problemCreater.GetComponent<problem_creater>().SpecialCalculation(this._solution);
    }

    public bool Judge(){
        return _answer==_correct;
    }

}
