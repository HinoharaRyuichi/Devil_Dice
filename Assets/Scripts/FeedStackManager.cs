using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedStackManager : MonoBehaviour
{
    // 餌スタックの数
    public int feedStackNum;

    // 餌スタックの上限値
    int feedStackUpperLimit;

    // 餌スタックの減少時間
    float FeedTimeOut;

    // feedStackのActive
    bool feedStackUIActive;

    // FeedStackのスクリプト
    public FeedStack feedStack;

    // GluttonyIconのゲームオブジェクト
    private GameObject gluttonyIcon;

    // GluttonyIconの非表示時間
    private float gluttonyIconTime;

    // Start is called before the first frame update
    void Start()
    {
        // 数値設定
        feedStackNum = 3;
        feedStackUpperLimit = 7;
        FeedTimeOut = 18.0f;

        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            feedStack = GameObject.Find("Panel").GetComponent<FeedStack>();
            gluttonyIcon = GameObject.Find("GluttonyIcon");
            gluttonyIconTime = 5.0f;

            // UI関連のオブジェクトのActiveをfalseに変更
            feedStackUIActive = false;
            feedStack.SetFeedStack(feedStackNum);
            feedStack.feedStackUI.SetActive(feedStackUIActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間経過後に餌スタックを1消費
        FeedTimeOut -= Time.deltaTime;
        if (feedStackNum > 0)
        {
            if (FeedTimeOut <= 0)
            {
                feedStack.EatFeedStack(1);
                feedStackNum -= 1;
                GameObject.Find("AudioManager").GetComponent<AudioManager>().GluttonyAudioPlay();
                FeedTimeOut = 14.0f;
            }
        }
        else
        {
            // GameManagerのGameOver関数を呼び出す
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Gluttony");
        }

        if (gluttonyIcon.activeSelf == false)
        {
            gluttonyIconTime -= Time.deltaTime;
            if (gluttonyIconTime <= 0)
            {
                gluttonyIcon.SetActive(true);
                gluttonyIconTime = 5.0f;
            }
        }
    }

    // マウスをクリックした時に呼び出す関数
    public void MouseClick()
    {
        // 餌スタックが0以下でなく
        if (feedStackNum > 0)
        {
            // 餌スタックが上限値未満であるなら
            if (feedStackNum < feedStackUpperLimit)
            {
                // 現在の餌スタックに1を足す
                feedStack.SetFeedStack(feedStackNum + 1);
                feedStackNum += 1;
                gluttonyIcon.SetActive(false);
            }
        } 
    }

    // feedStackUIActiveの切り替え
    public void feedStackUIActiveChange()
    {
        feedStackUIActive = !feedStackUIActive;
        feedStack.feedStackUI.SetActive(feedStackUIActive);
    }
}
