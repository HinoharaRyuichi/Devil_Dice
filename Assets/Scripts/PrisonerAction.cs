using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrisonerAction : MonoBehaviour
{
    //ゲッタセッタ受け取り用変数
    public Dice dice;

    //result
    int r;

    bool f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間ごとにサイコロの目によって行動するかを判断する
        f = dice.FragResult;

        

        if (f)
        {
            //resultに代入
            r = dice.Result;

            // day1シーンでのみやりたい処理
            if (SceneManager.GetActiveScene().name == "day1")
            {
                //resultが1のとき
                if (r == 1)
                {

                    Debug.Log("赤い目だ！");

                    //囚人行動
                    Action();
                }
            }

            // day2シーンでのみやりたい処理
            if (SceneManager.GetActiveScene().name == "day2")
            {

                //resultが1と2のとき
                if (r == 1 || r == 2)
                {

                    Debug.Log("赤い目だ！");

                    //囚人行動
                    Action();
                }
            }
        }
    }

    // 囚人の行動関数
    void Action()
    {
        // ダイスの名前によって行動が変化
        switch (dice.name)
        {
            // 憤怒の行動
            case "AngerDice":
                CageGauge cageGauge = GameObject.FindObjectOfType<CageGauge>();
                cageGauge.GaugeReduction(cageGauge.damage);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().AngerAudioPlay();
                break;
            // 暴食の行動
            case "GluttonyDice":
                FeedStackManager feedStackManager = GameObject.FindObjectOfType<FeedStackManager>();
                if (feedStackManager.feedStackNum > 0)
                {
                    feedStackManager.feedStack.EatFeedStack(1);
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().GluttonyAudioPlay();
                    feedStackManager.feedStackNum -= 1;
                }
                break;
            // 嫉妬の行動
            case "EnvyDice":
                GameObject.FindObjectOfType<EnvyManager>().EnvyUIActiveChange();
                break;
            // 怠惰の行動
            case "SlothDice":
                SlothManager slothManager = GameObject.FindObjectOfType<SlothManager>();
                if (slothManager.TimeStopFragResult == false)
                {
                    slothManager.SlothCircleShowChange();
                    slothManager.TimeStopFragResult = true;
                    if (slothManager.CameraShowNowResult == false)
                    {
                        slothManager.CameraShowNowResult = true;
                        slothManager.SlothCircleActiveChange();
                    }
                    // Debug.Log("TimeStopFragResult = " + slothManager.TimeStopFragResult);
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PCAudioActiveChange();
                }
                break;
            // 強欲の行動
            case "GreedDice":
                GreedManager greedManager = GameObject.FindObjectOfType<GreedManager>();
                if (greedManager.GreedPrisonerFragResult == false)
                {
                    greedManager.GreedPrisonerFragChange();
                    Debug.Log("GreedPrisonerActionStart");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().GreedStartAudioPlay();
                }
                break;
            // 色欲の行動
            case "LustDice":
                break;
            default:
                break;
        }
    }
}

