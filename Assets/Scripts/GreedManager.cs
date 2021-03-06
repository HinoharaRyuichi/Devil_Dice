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

    // 色欲の囚人
    [SerializeField]
    private GameObject LustPrisoner;

    // 強欲のコインUI
    [SerializeField]
    private GameObject GreedCoinUI;

    // 強欲のコインUIのActive
    private bool GreedCoinUIActive;

    // 憤怒の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject AngerPrisonCoinEffect;

    // 暴食の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject GluttonyPrisonCoinEffect;

    // 嫉妬の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject EnvyPrisonCoinEffect;

    // 怠惰の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject SlothPrisonCoinEffect;

    // 強欲の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject GreedPrisonCoinEffect;

    // 色欲の檻にコインがあるときのエフェクト
    [SerializeField]
    private GameObject LustPrisonCoinEffect;

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

    //探索するファイル
    const string DIR_COIN_IMAGES = "Coin";

    //アタッチされているオブジェ
    private Image m_CoinImage;

    // コインの画像のゲームオブジェクト
    [SerializeField]
    private GameObject CoinImage;

    //スプライト
    public Sprite[] m_CoinSprites;

    //画像の最大数
    public int LampIndex = 0;

    //探索するファイル
    const string DIR_LAMP_IMAGES = "Lamp";

    // Image コンポーネントを格納する変数
    private Image m_LampImage;

    // コインの画像のゲームオブジェクト
    [SerializeField]
    private GameObject LampImage;

    //スプライト
    public Sprite[] m_LampSprites;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            GreedCoinNum = 0;
            GreedCoinMaxNum = 9;
            Prisoner = 0;
            GreedGameOverWaitTime = 30.0f;
            GreedCoinAppearanceFrag = true;
            AngerPrisonCoinEffect.SetActive(false);
            GluttonyPrisonCoinEffect.SetActive(false);
            EnvyPrisonCoinEffect.SetActive(false);
            SlothPrisonCoinEffect.SetActive(false);
            GreedPrisonCoinEffect.SetActive(false);
            LustPrisonCoinEffect.SetActive(false);
            GreedCoinUIActive = false;
            GreedPrisonerFrag = false;
            GreedCoinUI.SetActive(GreedCoinUIActive);
            //GreedIconActive = false;
            //GreedIcon.SetActive(GreedIconActive);
            m_CoinSprites = Resources.LoadAll<Sprite>(DIR_COIN_IMAGES);
            m_CoinImage = CoinImage.GetComponent<Image>();
            m_CoinImage.sprite = m_CoinSprites[GreedCoinNum];

            // Retrieve all images in DIR_IMAGES
            m_LampSprites = Resources.LoadAll<Sprite>(DIR_LAMP_IMAGES);
            m_LampImage = LampImage.GetComponent<Image>();
            m_LampImage.sprite = m_LampSprites[LampIndex];
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

        if (GreedGameOverWaitTime <= 30 && GreedGameOverWaitTime > 20)
        {

            LampIndex = 0;
        }

        if (GreedGameOverWaitTime <= 20 && GreedGameOverWaitTime > 10)
        {

            LampIndex = 1;
        }

        if (GreedGameOverWaitTime <= 10)
        {

            LampIndex = 2;
        }

        //表示する画像を切替
        m_LampImage.sprite = m_LampSprites[LampIndex];

        m_CoinImage.sprite = m_CoinSprites[GreedCoinNum];
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

        if (Prisoner == 1)
        {

            AngerPrisonCoinEffect.SetActive(true);
        }

        if (Prisoner == 2)
        {

            GluttonyPrisonCoinEffect.SetActive(true);
        }

        if (Prisoner == 3)
        {

            EnvyPrisonCoinEffect.SetActive(true);
        }

        if (Prisoner == 4)
        {

            SlothPrisonCoinEffect.SetActive(true);
        }

        if (Prisoner == 5)
        {

            GreedPrisonCoinEffect.SetActive(true);
        }

        if (Prisoner == 6)
        {

            LustPrisonCoinEffect.SetActive(true);
        }

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
            AngerPrisonCoinEffect.SetActive(false);
            GluttonyPrisonCoinEffect.SetActive(false);
            EnvyPrisonCoinEffect.SetActive(false);
            SlothPrisonCoinEffect.SetActive(false);
            GreedPrisonCoinEffect.SetActive(false);
            LustPrisonCoinEffect.SetActive(false);
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

    // 強欲の囚人にコインを3枚渡す関数
    public void GreedCoinPresent ()
    {
        if (GreedPrisonerFrag)
        {
            if (GreedCoinNum >= 3)
            {
                GreedCoinNum -= 3;
                GreedGameOverWaitTime = 30.0f;
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
