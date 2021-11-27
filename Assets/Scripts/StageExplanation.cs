using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExplanation : MonoBehaviour
{
    //ステージ説明ポインタ引き渡し用変数
    private int StageExplanationResult;

    //出目引き渡し用ゲッタセッタ
    public int Result
    {

        get { return this.StageExplanationResult; }
        private set { this.StageExplanationResult = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        StageExplanationResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ステージ選択にてday1を説明する画像を表示する関数
    public void Day1Choice ()
    {
        Debug.Log("Day1_Choice");
        StageExplanationResult = 1;
    }

    // ステージ選択にてday2を説明する画像を表示する関数
    public void Day2Choice()
    {
        Debug.Log("Day2_Choice");
        StageExplanationResult = 2;
    }

    // ステージ選択にてday3を説明する画像を表示する関数
    public void Day3Choice()
    {
        Debug.Log("Day3_Choice");
        StageExplanationResult = 3;
    }

    // ステージ選択にてday4を説明する画像を表示する関数
    public void Day4Choice()
    {
        Debug.Log("Day4_Choice");
        StageExplanationResult = 4;
    }

    // ステージ選択にてday5を説明する画像を表示する関数
    public void Day5Choice()
    {
        Debug.Log("Day5_Choice");
        StageExplanationResult = 5;
    }

    // ステージ選択にてデフォルト画像を表示する関数
    public void DefaultDay()
    {
        Debug.Log("Default");
        StageExplanationResult = 0;
    }
}
