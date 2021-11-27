using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRender : MonoBehaviour
{
    //ゲッタセッタ受け取り用変数
    public Dice dice;
    //result
    int r;
    bool f;

    //画像の最大数
    public int index = 0;

    //探索するファイル
    const string DIR_IMAGES = "dice";
    //アタッチされているオブジェ
    SpriteRenderer m_SpriteRenderer;

    //スプライト
    public Sprite[] m_Sprites;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {

        //resultに代入
        r = dice.Result;

        f = dice.FragResult;

        if (f == true)
        {
            switch (r)
            {

                //1の目
                case 1:

                    //赤の1の目
                    index = 0;

                    break;

                //2の目
                case 2:

                    if (SceneManager.GetActiveScene().name == "day1")
                    {

                        //白の2の目
                        index = 6;
                    }

                    else
                    {

                        //赤の2の目
                        index = 1;
                    }

                    break;

                //3の目
                case 3:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2")
                    {

                        //赤の3の目
                        index = 7;
                    }

                    else
                    {

                        //白の3の目
                        index = 2;
                    }

                    break;

                //4の目
                case 4:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3")
                    {

                        //白の4の目
                        index = 8;
                    }

                    else
                    {

                        //赤の4の目
                        index = 3;
                    }

                    break;

                //5の目
                case 5:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4")
                    {

                        //白の5の目
                        index = 9;
                    }

                    else
                    {

                        //赤の5の目
                        index = 5;
                    }

                    break;

                //6の目
                case 6:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4" ||
                        SceneManager.GetActiveScene().name == "day5")
                    {

                        //白の6の目
                        index = 10;
                    }

                    else
                    {

                        //赤の6の目
                        index = 6;
                    }

                    break;

                default:
                    break;
            }
        }
        //表示する画像を切替
        m_SpriteRenderer.sprite = m_Sprites[index];
    }
}
