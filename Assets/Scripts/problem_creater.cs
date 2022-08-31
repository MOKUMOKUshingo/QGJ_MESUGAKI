using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class problem_creater : MonoBehaviour
{
    [SerializeField] private int shown_max_p;
    [SerializeField] private int hidden_max_p;

    public int[][] _problem;
    public int _answer;

    // Start is called before the first frame update
    void Start()
    {         
        
    }
    /// <summary>
    /// _problem and _answer is changed
    /// </summary>
    /// <param name="element_num"></param>
    /// <param name="calcular_type_num"></param>
    /// <param name="dummy_num"></param>
    /// <returns></returns>

    public void ProblemCreater(int element_num,int calcular_type_num){
        int answer_=0;
        int[][] problem_ = new int[2][];
        problem_[0] = new int[element_num];
        problem_[1] = new int[element_num-1];

        for(;!isValidProblem(answer_);){
            
            for(var i=0;i<element_num;i++){
                problem_[0][i] = UnityEngine.Random.Range(0,this.shown_max_p);
            }
            
            for(var i=0;i<element_num-1;i++){
                problem_[1][i] = UnityEngine.Random.Range(0,calcular_type_num);
            }
            answer_ = SpecialCalculation(problem_);
            
        }
        this._answer = answer_;
        this._problem = problem_;
    }

    private bool isValidProblem(int num){
        return 1 <= num && num <= hidden_max_p;
    }

    public int SpecialCalculation(int[][] problem_){

        if(Array.Find(problem_[1],p => p == 2)>0){

            int multiply_location = Array.FindIndex(problem_[1],p => p==2);
            problem_[0][multiply_location] = problem_[0][multiply_location]*problem_[0][multiply_location + 1];
            problem_[0][multiply_location+1] = 0;
            problem_[1][multiply_location] = 0;
            
            return SpecialCalculation(problem_);
        
        }else{
            int answer = 0;
            answer += problem_[0][0];
            for(int i = 1;i<problem_[0].Length;i++){
                if(problem_[1][i-1]==0){
                    answer += problem_[0][i];
                }else{
                    answer -= problem_[0][i];
                }
            }
            
            return answer;
        
        }

    }

    public void QuestionCreater(int element_num,int calcular_type_num){
        //_problem and _answer is completed
        ProblemCreater(element_num,calcular_type_num);
        
    }
}
