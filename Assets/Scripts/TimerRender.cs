using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRender : MonoBehaviour
{
    //時間計る用
    private float time;

    // 1時間の秒数
    private float hour;

    //画像の最大数
    private int index = 0;

    //探索するファイル
    const string DIR_IMAGES = "Time";
    //アタッチされているオブジェ
    SpriteRenderer m_SpriteRenderer;

    //スプライト
    public Sprite[] m_Sprites;

    // クリア後のシーンチェンジまでの待機時間
    private float changeTime;

    // SlothManagerのゲームオブジェクト
    [SerializeField]
    private GameObject SlothManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期値設定(デバック用に5を設定)
        // ゲームレベル設定や提出の際には再設定を忘れないこと
        hour = 35.0f;
        time = hour * 6;
        changeTime = 0.5f;

        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (SlothManager.activeSelf)
        {
            if (SlothManager.GetComponent<SlothManager>().TimeStopFragResult == false)
            {
                //時間を減らす
                time -= Time.deltaTime;
            }
        }
        else
        {
            //時間を減らす
            time -= Time.deltaTime;
        }
        
        

        //00:00
        if (time / hour >= 5)
        {

            //表示する画像を設定(1)
            index = 0;
        }

        //01:00
        else if (time / hour >= 4)
        {

            //表示する画像を設定(2)
            index = 1;
        }

        //02:00
        else if (time / hour >= 3)
        {

            //表示する画像を設定(3)
            index = 2;
        }

        //03:00
        else if (time / hour >= 2)
        {

            //表示する画像を設定(4)
            index = 3;
        }

        //04:00
        else if (time / hour >= 1)
        {

            //表示する画像を設定(5)
            index = 4;
        }

        //05::00
        else if (time <= hour && time >= 0)
        {

            //表示する画像を設定(5)
            index = 5;
        }

        //06:00
        else
        {
            index = 6;
            if (changeTime >= 0.0f)
            {
                changeTime -= Time.deltaTime;
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().GameClear();
            }
        }

        //表示する画像を切替
        m_SpriteRenderer.sprite = m_Sprites[index];
    }
}
