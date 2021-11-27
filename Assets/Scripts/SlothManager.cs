using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlothManager : MonoBehaviour
{
    // 怠惰のサイクルの画像
    private Image SlothImage;

    // サイクルの現在の値
    private float SlothCircleValue;

    // サイクルの最大値
    private float SlothCircleMaxValue;

    // サイクルの値を増やす際に参照される値
    private float SlothCircleSecondValue;

    // マウスのボタンを押したときtrue、離したときにfalseになるフラグ
    private bool MouseButtonDownFlag;

    // SlothCircleUIを表示すべきかどうかを管理する変数(true:表示する false:表示しない)
    private bool SlothCircleShow;

    // SlothCircleのGameObject
    private GameObject SlothCircle;

    // SlothCircleIconのGameObject
    private GameObject SlothIcon;

    // SlothCircleUIのActive
    private bool SlothCircleUIActive;

    // 今どの画面を見ているかを判別する変数(trueならデフォルト画面、falseなら怠惰の画面)
    private bool CameraShowNow;

    // CameraShowNow用ゲッタセッタ
    public bool CameraShowNowResult
    {
        get { return this.CameraShowNow; }
        set { this.CameraShowNow = value; }
    }

    // 時間停止フラグ変数
    private bool TimeStopFrag;

    // TimeStopFrag用ゲッタセッタ
    public bool TimeStopFragResult
    {
        get { return this.TimeStopFrag; }
        set { this.TimeStopFrag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 数値設定
        SlothCircleValue = 0;
        SlothCircleMaxValue = 3000;
        SlothCircleSecondValue = 10;

        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            SlothImage = GameObject.Find("SlothCircle").GetComponent<Image>();
            SlothCircle = GameObject.Find("SlothCircle");
            SlothIcon = GameObject.Find("SlothIcon");
            MouseButtonDownFlag = false;
            SlothCircleShow = false;
            SlothCircleUIActive = false;
            SlothImage.fillAmount = 0;
            SlothCircle.SetActive(SlothCircleUIActive);
            SlothIcon.SetActive(SlothCircleUIActive);
            CameraShowNow = true;
            TimeStopFrag = false;
            Debug.Log("CameraShowNow = " + CameraShowNow);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day") && SlothCircleShow == true)
        {
            if (MouseButtonDownFlag)
            {
                // ボタンを押している間サイクルの値を増やす
                CircleIncrease(SlothCircleSecondValue);
                if (SlothCircleValue >= SlothCircleMaxValue)
                {
                    SlothImage.fillAmount = 0;
                    SlothCircleValue = 0;
                    TimeStopFrag = false;
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PCAudioActiveChange();
                    // SlothCircleShow = false;
                    MouseButtonDownFlag = false;
                    SlothCircleShowChange();
                    SlothCircleActiveChange();
                    CameraShowNow = false;
                }
            }
            else
            {
                // 常にサイクルの値を0にする
                SlothImage.fillAmount = 0;
                SlothCircleValue = 0;
            }
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
        // マウスのボタンを押しているかのフラグをfalseに変更
        MouseButtonDownFlag = false;
    }

    // サイクルの値を増やす関数
    public void CircleIncrease(float IncreaseValue)
    {
        var ValueTo = (SlothCircleValue + IncreaseValue) / SlothCircleMaxValue;
        SlothImage.fillAmount = ValueTo;
        // 檻ゲージのライフの数値も増加
        SlothCircleValue += IncreaseValue;
    }

    // SlothCircleUIのActive切り替え
    public void SlothCircleActiveChange ()
    {
        CameraShowNow = !CameraShowNow;
        Debug.Log("CameraShowNow = " + CameraShowNow);
        if (CameraShowNow)
        {
            SlothCircleUIActive = false;
            SlothCircle.SetActive(SlothCircleUIActive);
            SlothIcon.SetActive(SlothCircleUIActive);
        }
        else
        {
            if (SlothCircleShow)
            {
                SlothCircleUIActive = true;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
            else
            {
                SlothCircleUIActive = false;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
        }
        
    }

    public void SlothCircleShowChange ()
    {
        SlothCircleShow = !SlothCircleShow;
        Debug.Log("SlothCircleShow = " + SlothCircleShow);
        /*if (SlothCircleShow)
        {
            if (CameraShowNow == false)
            {
                SlothCircleUIActive = true;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
        }*/
    }
}
