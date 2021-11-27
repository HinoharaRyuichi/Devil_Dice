using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeedStack : MonoBehaviour
{
    // 餌スタックプレハブ
    [SerializeField]
    private GameObject FeedstackObj;

    // feedStackUIのスクリプト
    public GameObject feedStackUI;

    // Start is called before the first frame update
    void Start()
    {
        // シーン名に単語のdayを含むシーンでのみ行う処理
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            feedStackUI = GameObject.Find("Panel");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    // 餌スタック全削除＆初期値分作成
    public void SetFeedStack(int life)
    {
        // 餌スタックを一旦全削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        // 現在の餌スタック数分のライフゲージを作成
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(FeedstackObj, transform);
        }
    }
    // 食事の消費分だけ削除
    public void EatFeedStack (int consumption)
    {
        for (int i = 0; i < consumption; i++)
        {
            // 最後のライフゲージを削除
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
