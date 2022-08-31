using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    private int girlHeight;
    [SerializeField]private int local_time_limit;
    [SerializeField]private int global_time_limit;
    private float localTimer;
    private float globalTimer;
    private bool isOngoing = true;
    //{"問題作成時間","解答時間","答え合わせ時間"}
    public string phase;

    AudioSource audioSource;
    

    public int levelOfGirl; //7段階以上あるかも
    [SerializeField]private int minLevelOfGirl;
    private double[] Heights = new double[6]{0.1, 0.2, 2, 3, 4000, 5000};

    private GameObject[] timeManager = new GameObject[2];
    private GameObject scoreManager;
    private GameObject gameItemsManager;

    public GameObject displayManager;
    
    private int[][] difficulties = new int[7][];
    [SerializeField]private int[] diffi0 = new int[3]{2,2,1};
    [SerializeField]private int[] diffi1 = new int[3]{2,2,1};
    [SerializeField]private int[] diffi2 = new int[3]{2,3,0};
    [SerializeField]private int[] diffi3 = new int[3]{3,2,0};
    [SerializeField]private int[] diffi4 = new int[3]{3,2,1};
    [SerializeField]private int[] diffi5 = new int[3]{3,3,0};
    [SerializeField]private int[] diffi6 = new int[3]{3,3,1};


    // Start is called before the first frame update
    void Start()
    {
        var ChildrenTransforms = this.transform.GetComponentsInChildren<Transform>();
        
        timeManager[0] = ChildrenTransforms[2].gameObject;
        timeManager[1] = ChildrenTransforms[3].gameObject;
        scoreManager = ChildrenTransforms[4].gameObject;
        gameItemsManager = GameObject.Find("GameItemsManager");
        audioSource = GetComponent<AudioSource>();

        this.difficulties[0] = diffi0;
        this.difficulties[1] = diffi1;
        this.difficulties[2] = diffi2;
        this.difficulties[3] = diffi3;
        this.difficulties[4] = diffi4;
        this.difficulties[5] = diffi5;
        this.difficulties[6] = diffi6;

        this.levelOfGirl = 0;
        globalTimer = 0;
        timeManager[1].GetComponent<globalTimerManager>().SetupTimer(global_time_limit);

        NextCycle(0);

        


    }
    
    
    //HighLowは-1,0,1で次の状態を決定
    public void NextCycle(int HighLow){
        phase = "答え合わせ時間";
        //初期化
        this.localTimer = 0;
        timeManager[0].GetComponent<localTimerManager>().SetupTimer(local_time_limit);


        //イラスト遷移処理
        //失敗したときはAudio
        this.levelOfGirl += HighLow;

        if(minLevelOfGirl>this.levelOfGirl){
            Debug.Log("できなくて終了。リザルトへ");
            displayManager.GetComponent<DisplayManager>().RequestSceneChangeTo(5);
        }else{
            var girlScript = gameItemsManager.GetComponent<CalculationManager>()._girl.GetComponent<girlController>();
            girlScript._sprite.GetComponent<MyTransformation>().Transforming(levelOfGirl);
            if(levelOfGirl<=1){
                girlScript._background.GetComponent<MyTransformation>().Transforming(0);
            }else if(levelOfGirl==2){
                girlScript._background.GetComponent<MyTransformation>().Transforming(1);
            }else{
                girlScript._background.GetComponent<MyTransformation>().Transforming(2);
            }
        }

        phase = "問題作成時間";
        //問題作成処理


        //時間を少し置く処理がほしい。
        phase = "解答時間";
        audioSource.Play();
    }

    private void Update() {
        if(isOngoing){
            localTimer += Time.deltaTime;
            timeManager[0].GetComponent<localTimerManager>().ManageTimer(localTimer);
            if(localTimer>local_time_limit){
                Debug.Log("時間切れ");
                NextCycle(-1);
            }
            globalTimer += Time.deltaTime;
            timeManager[1].GetComponent<globalTimerManager>().ManageTimer(globalTimer);
            if(globalTimer>global_time_limit){
                Debug.Log("タイムアップ終了。リザルトへ");
                displayManager.GetComponent<DisplayManager>().RequestSceneChangeTo(5);
            }
        }

    }


}
