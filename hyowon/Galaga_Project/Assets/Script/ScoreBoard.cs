using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;
    public float Score;
    public Text text_Score;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text_Score.text = "현재 점수 : " + Mathf.Round(Score);
    }
}
