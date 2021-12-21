using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CageGauge : MonoBehaviour
{
    // 檻ゲージ
    [SerializeField]
    private Image GreenGauge;

    // マウスのボタンを押したときtrue、離したときにfalseになるフラグ
    private bool MouseButtonDownFlag = false;

    // 檻ゲージのHP
    public float CageLife;

    // 檻ゲージの最大HP
    public float CageMaxLife;

    // 檻ゲージへ毎秒与えるダメージ量
    float secondDamage;

    // サイコロの赤い目が出た際に檻ゲージに与えるダメージ
    public float damage;

    // アイコンを押している間の檻ゲージの回復量
    float recovery;

    // cageGaugeUIスクリプト
    //private GameObject cageGaugeUI;

    // cageGaugeのActive
    //bool cageGaugeUIActive;

    // 憤怒檻ボタンを押したときのSEようフラグ渡し
    public bool MouseButtonFrag
    {
        get { return this.MouseButtonDownFlag; }
        private set { this.MouseButtonDownFlag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 数値設定
        CageLife = 1000f;
        CageMaxLife = 1000f;
        secondDamage = 0.5f;
        damage = 100f;
        recovery = 2f;

        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            //cageGaugeUI = GameObject.Find("CageGauge");

            // UI関連のオブジェクトのActiveをfalseに変更
            //cageGaugeUIActive = false;
            //cageGaugeUI.SetActive(cageGaugeUIActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // timeScaleが0ならその後の処理をしない
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            if (MouseButtonDownFlag)
            {
                // ボタンを押している間檻ゲージ回復
                GaugeIncrease(recovery);
            }
            else
            {
                // 常に檻ゲージが減少
                GaugeReduction(secondDamage);
            }
        }
    }

    // 檻ゲージを減少させる関数
    public void GaugeReduction(float reducationValue)
    {
        var ValueTo = (CageLife - reducationValue) / CageMaxLife;
        GreenGauge.fillAmount = ValueTo;
        // 檻ゲージのライフの数値も減少
        CageLife -= reducationValue;
        if (CageLife <= 0)
        {
           // GameManagerのGameOver関数を呼び出す
           GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Anger");
        }
    }

    // 檻ゲージを増加する関数
    public void GaugeIncrease(float IncreaseValue)
    {
        if (CageLife + IncreaseValue < CageMaxLife)
        {
            var ValueTo = (CageLife + IncreaseValue) / CageMaxLife;
            GreenGauge.fillAmount = ValueTo;
            // 檻ゲージのライフの数値も増加
            CageLife += IncreaseValue;
        }
    }

    // マウスのボタンを押したときの処理
    public void OnButtonDown()
    {
        // マウスのボタンを押しているかのフラグをtrueに変更
        MouseButtonDownFlag = true;
    }

    // マウスのボタンを離したときの処理
    public void OnButtonUp()
    {
        if (MouseButtonDownFlag)
        {
            // マウスのボタンを押しているかのフラグをfalseに変更
            MouseButtonDownFlag = false;
        }
    }

    // マウスのボタンから離れたときの処理
    public void OnButtonExit ()
    {
        if (MouseButtonDownFlag)
        {
            // マウスのボタンを押しているかのフラグをfalseに変更
            MouseButtonDownFlag = false;
        }
    }

    /*
    // cageGaugeUIのActive切り替え
    public void cageGaugeUIActiveChange()
    {
        cageGaugeUIActive = !cageGaugeUIActive;
        cageGaugeUI.SetActive(cageGaugeUIActive);
    }
    */
}
