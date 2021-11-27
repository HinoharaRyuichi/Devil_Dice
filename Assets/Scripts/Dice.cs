using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //サイコロを転がすまでのクールタイム
    public float DiceTime;
    //2Dテスト用乱数
    private int Ran;
    //出目引き渡し用変数
    private int DiceResult;

    // ダイス振ったかのフラグ
    private bool DiceFrag;

    //出目引き渡し用ゲッタセッタ
    public int Result
    {

        get { return this.DiceResult; }
        private set { this.DiceResult = value; }
    }

    // ダイス振ったかのフラグ用ゲッタセッタ
    public bool FragResult
    {

        get { return this.DiceFrag; }
        private set { this.DiceFrag = true; }
    }

    // Start is called before the first frame update
    void Start()
    {

        //初期値5(テストのため)
        DiceTime = 7.0f;
        //初期化
        DiceResult = 0;

        DiceFrag = false;
    }

    // Update is called once per frame
    void Update()
    {

        //サイコロを振るまでの時間を減らす
        DiceTime -= Time.deltaTime;

        //クールタイムが0になったとき
        if (DiceTime < 0)
        {
            //2D用乱数
            Ran = Random.Range(1, 7);

            //クールタイムを初期値に戻す
            DiceTime = 7.0f;

            DiceFrag = true;
        }

        else
        {
            //2D出目の確認
            if (Ran >= 1 && Ran <= 6)
            {
                DiceResult = Ran;
                DiceFrag = false;
            }
        }
    }
}
