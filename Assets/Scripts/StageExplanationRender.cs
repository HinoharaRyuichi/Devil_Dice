using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageExplanationRender : MonoBehaviour
{
    //ゲッタセッタ受け取り用変数
    public StageExplanation stageExplanation;
    //result
    int r;
    //画像の最大数
    public int index = 0;

    //探索するファイル
    const string DIR_IMAGES = "StageExplanation";

    // Image コンポーネントを格納する変数
    private Image m_Image;

    //スプライト
    public Sprite[] m_Sprites;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_Image = gameObject.GetComponent<Image>();
        m_Image.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {

        //resultに代入
        r = stageExplanation.Result;

        //キーを押したとき 表示を切替(テスト
        if (true)
        {

            if (r == 1)
            {

                //表示する画像を設定(1)
                index = 0;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 2)
            {

                //表示する画像を設定(2)
                index = 1;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 3)
            {

                //表示する画像を設定(3)
                index = 2;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 4)
            {

                //表示する画像を設定(4)
                index = 3;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 5)
            {

                //表示する画像を設定(5)
                index = 4;
                //Debug.Log("m_index: " + index);
            }

            else
            {

                //表示する画像を設定(6)
                index = 5;
                //Debug.Log("m_index: " + index);
            }

            //表示する画像を切替
            m_Image.sprite = m_Sprites[index];
        }
    }
}
