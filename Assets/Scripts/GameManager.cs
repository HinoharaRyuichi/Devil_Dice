using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    //ゲームオーバー時のアニメーションを再生する画像
    private GameObject GameOverImage;

    // Gulltonyによってゲームオーバーになった際に表示する画像
    private GameObject gulltonyImage;

    // Angerによってゲームオーバーになった際に表示する画像
    private GameObject angerImage;

    // Greedによってゲームオーバーになった際に表示する画像
    private GameObject greedImage;

    // GameClearになった時に表示する画像
    private GameObject gameClear;

    // Windowを変えた際に一瞬だけ表示される画像
    private GameObject windowChange;

    // windowChangeのActive
    private bool windowChangeActive;

    // 上記の画像を表示する時間
    private float WindowChangeWaitTime;

    // 囚人管理のゲームオブジェクトを動かしているか
    private bool PrisonerActionOver;

    // 囚人管理のゲームオブジェクトを動かしているか
    private bool PrisonerActionClear;

    // 画面遷移までの待機時間
    private float GameSceneChangeTime;

    // 最初に写したいカメラ
    [SerializeField]
    private GameObject FirstCamera;

    // 時計のゲージ(デフォルト)
    private GameObject TimeCircleDefault;

    // 時計のゲージ(増減用)
    private GameObject TimeCircle;

    // 時計表示をするか判断するためのフラグ
    //private bool TimeCircleFrag;

    // 透明度を変更するパネルのイメージ
    [SerializeField]
    private Image FadeImage;

    // パネルの色
    private Color PanelColor;

    // フェードアウトにかかる時間
    private float Duration;

    // スタートボタンの画像
    private Image StartButton;

    // マウスクリックの画像
    [SerializeField]
    private GameObject MauseClick;

    private void Awake()
    {
        // 初期設定
        Screen.SetResolution(1920, 1080, true);
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        // FadeImage = default;
        // PanelColor = Color.black;
        var c = FadeImage.color;
        c.a = 0f;
        FadeImage.color = c;
        Duration = 1.0f;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            StartButton = GameObject.Find("StartButton").GetComponent<Image>();
            var sbc = StartButton.color;
            sbc.a = 1f;
            StartButton.color = sbc;
        }

        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            GameOverImage = GameObject.Find("GameOverAnimImage");
            gulltonyImage = GameObject.Find("GulltonyGameOver");
            angerImage = GameObject.Find("AngerGameOver");
            greedImage = GameObject.Find("GreedGameOver");
            GameOverImage.SetActive(false);
            gulltonyImage.SetActive(false);
            angerImage.SetActive(false);
            greedImage.SetActive(false);
            // GameOverWaitTime = 3.0f;
            gameClear = GameObject.Find("GameClear");
            gameClear.SetActive(false);
            // GameClearWaitTime = 3.0f;
            windowChange = GameObject.Find("WindowChange");
            windowChangeActive = false;
            windowChange.SetActive(windowChangeActive);
            WindowChangeWaitTime = 0.5f;
            PrisonerActionOver = true;
            PrisonerActionClear = true;
            GameSceneChangeTime = 4.0f;
            FirstCamera.GetComponent<CinemachineVirtualCamera>().MoveToTopOfPrioritySubqueue();
            TimeCircleDefault = GameObject.Find("TimeCircleDefault");
            TimeCircle = GameObject.Find("TimeCircle");
            //TimeCircleFrag = true;
            MauseClick.SetActive(false);
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

        if (windowChangeActive)
        {
            WindowChangeWaitTime -= Time.deltaTime;
            if (WindowChangeWaitTime <= 0)
            {
                WindowChangeWaitTime = 0.5f;
                WindowChange();
            }
        }

        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            if (!PrisonerActionOver)
            {
                GameSceneChangeTime -= Time.deltaTime;
                if (Input.GetMouseButton(0) && GameSceneChangeTime <= 0)
                {
                    ChangeScene("GameOver");
                }
            }

            if (!PrisonerActionClear)
            {
                GameSceneChangeTime -= Time.deltaTime;
                if (Input.GetMouseButton(0) && GameSceneChangeTime <= 0)
                {
                    ChangeScene("GameClear");
                }
            }

            if (GameSceneChangeTime <= 0)
            {
                MauseClick.SetActive(true);
            }
        }
    }
    
    // シーン切り替え用の関数
    public void ChangeScene(string nextScene)
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            DOTween.ToAlpha(
            () => StartButton.color,
            color => StartButton.color = color,
            0f,
            Duration
            );
        }


        DOTween.ToAlpha(
            () => FadeImage.color,
            color => FadeImage.color = color,
            1f,
            Duration
            ).OnComplete(() => SceneManager.LoadScene(nextScene));
        
    }

    // GameOver時に呼ばれる関数
    public void GameOver (string death)
    {
        GameObject.Find("PrisonerManager").SetActive(false);
        GameObject.Find("PrisonerAction").SetActive(false);
        GameObject.Find("TimeRender").SetActive(false);

        GameOverImage.SetActive(true);

        switch (death)
        {
            // 暴食によって〇された時
            case "Gluttony":
                Debug.Log("Gluttony death");
                gulltonyImage.SetActive(true);
                break;
            // 憤怒によって〇された時
            case "Anger":
                Debug.Log("Anger death");
                angerImage.SetActive(true);
                break;
            // 強欲によって〇された時
            case "Greed":
                Debug.Log("Greed death");
                greedImage.SetActive(true);
                break;
            default:
                break;
        }

        PrisonerActionOver = false;
    }

    // GameClear時に呼ばれる関数
    public void GameClear ()
    {
        GameObject.Find("PrisonerManager").SetActive(false);
        GameObject.Find("PrisonerAction").SetActive(false);
        GameObject.Find("TimeRender").SetActive(false);

        Debug.Log("Game Clear");
        gameClear.SetActive(true);

        PrisonerActionClear = false;
    }

    public void WindowChange ()
    {
        windowChangeActive = !windowChangeActive;
        if (windowChangeActive)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().CameraChangeAudioResult.Play();
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().CameraChangeAudioResult.Stop();
        }
        
        windowChange.SetActive(windowChangeActive);
    }

    /*
    public void TimeCircleChange ()
    {
        TimeCircleFrag = !TimeCircleFrag;
        TimeCircleDefault.SetActive(TimeCircleFrag);
        TimeCircle.SetActive(TimeCircleFrag);
    }
    */

    // timeScaleの変更
    public void TimeScaleChange ()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
