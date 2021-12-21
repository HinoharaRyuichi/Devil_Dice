using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GreedManager : MonoBehaviour
{
    // GreedCoinの枚数
    private int GreedCoinNum;

    // GreedCoinの上限枚数
    private int GreedCoinMaxNum;

    // GreedCoinの出現フラグ
    private bool GreedCoinAppearanceFrag;

    // どの囚人の画面にコインを出現させるか
    private int Prisoner;

    // 憤怒の囚人
    [SerializeField]
    private GameObject AngerPrisoner;

    // 暴食の囚人
    [SerializeField]
    private GameObject GluttonyPrisoner;

    // 嫉妬の囚人
    [SerializeField]
    private GameObject EnvyPrisoner;

    // 怠惰の囚人
    [SerializeField]
    private GameObject SlothPrisoner;

    // 強欲の囚人
    [SerializeField]
    private GameObject GreedPrisoner;

    // 強欲のコインUI
    [SerializeField]
    private GameObject GreedCoinUI;

    // 強欲のコインUIのActive
    private bool GreedCoinUIActive;

    // GreedPrisonerを動かすかのフラグ
    private bool GreedPrisonerFrag;

    // GreedPrisonerのフラグ用ゲッター
    public bool GreedPrisonerFragResult
    {
        get { return this.GreedPrisonerFrag; }
    }

    // ゲームオーバーになるまでの制限時間
    private float GreedGameOverWaitTime;

    // 強欲のIconのゲームオブジェクト
    [SerializeField]
    private GameObject GreedIcon;

    // 強欲のIconのActive
    //private bool GreedIconActive;

    // 色欲の囚人
    [SerializeField]
    private GameObject LustPrisoner;

    //探索するファイル
    const string DIR_IMAGES = "Coin";

    //アタッチされているオブジェ
    Image m_SpriteRenderer;

    // コインの画像のゲームオブジェクト
    [SerializeField]
    private GameObject CoinImage;

    //スプライト
    public Sprite[] m_Sprites;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            GreedCoinNum = 0;
            GreedCoinMaxNum = 9;
            Prisoner = 0;
            GreedGameOverWaitTime = 20.0f;
            GreedCoinAppearanceFrag = true;
            GreedCoinUIActive = false;
            GreedPrisonerFrag = false;
            GreedCoinUI.SetActive(GreedCoinUIActive);
            //GreedIconActive = false;
            //GreedIcon.SetActive(GreedIconActive);
            m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
            m_SpriteRenderer = CoinImage.GetComponent<Image>();
            m_SpriteRenderer.sprite = m_Sprites[GreedCoinNum];
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

        if (GreedCoinAppearanceFrag)
        {
            GreedCoinAppearance();
        }

        if (GreedPrisonerFrag)
        {
            GreedGameOver();
        }

        m_SpriteRenderer.sprite = m_Sprites[GreedCoinNum];
    }

    // 強欲コイン出現決定関数
    public void GreedCoinAppearance ()
    {
        // どの囚人の画面にコインを出現させるかを決定する
        do
        {
            Prisoner = Random.Range(1, 7);
            switch (Prisoner)
            {
                case 1:
                    if (!AngerPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                case 2:
                    if (!GluttonyPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                case 3:
                    if (!EnvyPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                case 4:
                    if (!SlothPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                case 5:
                    if (!GreedPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                case 6:
                    if (!LustPrisoner.activeSelf)
                    {
                        Prisoner = 0;
                    }
                    break;
                default:
                    break;
            }
        } while (Prisoner == 0);
        
        GreedCoinAppearanceFrag = false;
    }

    // 強欲のコインUIの表示の関数
    public void GreedCoinUIActiveChange (int Camera)
    {
        if (GreedPrisoner.activeSelf)
        {
            if (Camera == Prisoner)
            {
                GreedCoinUIActive = true;
                GreedCoinUI.SetActive(GreedCoinUIActive);
            }
            else
            {
                GreedCoinUIActive = false;
                GreedCoinUI.SetActive(GreedCoinUIActive);
            }
        }
        
    }

    // 強欲コインを1枚ゲットする関数
    public void GreedCoinGet ()
    {
        if (GreedCoinNum < GreedCoinMaxNum)
        {
            GreedCoinNum += 1;
            GreedCoinAppearanceFrag = true;
            GreedCoinUI.SetActive(false);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().GreedCoinGetAudioPlay();
        }
        
    }

    // 強欲の囚人のゲームオーバーに関するあれこれをする関数
    public void GreedGameOver ()
    {
        GreedGameOverWaitTime -= Time.deltaTime;
        if (GreedGameOverWaitTime <= 0)
        {
            // GameManagerのGameOver関数を呼び出す
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Greed");
        }
    }

    // 強欲の囚人にコインを5枚渡す関数
    public void GreedCoinPresent ()
    {
        if (GreedPrisonerFrag)
        {
            if (GreedCoinNum >= 3)
            {
                GreedCoinNum -= 3;
                GreedGameOverWaitTime = 15.0f;
                GreedPrisonerFragChange();
                GameObject.Find("AudioManager").GetComponent<AudioManager>().GreedCoinPresentAudioPlay();
            }
        }
    }

    /*
    // 強欲のIconのActive切り替え
    public void GreedIconActiveChange ()
    {
        GreedIconActive = !GreedIconActive;
        GreedIcon.SetActive(GreedIconActive);
    }
    */

    // GreedPrisonerFragの切り替え
    public void GreedPrisonerFragChange ()
    {
        GreedPrisonerFrag = !GreedPrisonerFrag;
    }
}
