using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // 暴食のAudioSourceコンポーネント
    [SerializeField]
    private AudioSource GluttonyAudioSource;

    // 暴食のAudioClipコンポーネント
    [SerializeField]
    private AudioClip GluttonyAudioClip;

    // 暴食のSEのActive
    private bool GluttonyAudionActive;

    // 暴食のSEの再生時間
    private float GluttonyAudioPlayTime;

    // PCのAudioSourceコンポーネント
    [SerializeField]
    private AudioSource PCAudioSource;

    // PCのSEのActive
    private bool PCAudionActive;

    // PCのSEのActive用ゲッタセッタ
    public bool PCAudionActiveResult
    {
        get { return this.PCAudionActive; }
        private set { this.PCAudionActive = value; }
    }

    // 憤怒のAudioSourceコンポーネント
    [SerializeField]
    private AudioSource AngerAudioSource;

    // 憤怒のAudioClipコンポーネント
    [SerializeField]
    private AudioClip AngerAudioClip;

    // 監視カメラを切り替えた時のSEのコンポーネント
    [SerializeField]
    private AudioSource CameraChangeAudioSource;

    public AudioSource CameraChangeAudioResult
    {
        get { return this.CameraChangeAudioSource; }
        private set { this.CameraChangeAudioSource = value; }
    }

    // 嫉妬のAudioSourceコンポーネント1個目
    [SerializeField]
    private AudioSource EnvyAudioSource1;

    // 嫉妬のAudioSourceコンポーネント2個目
    [SerializeField]
    private AudioSource EnvyAudioSource2;

    // 嫉妬のAudioSourceコンポーネント3個目
    [SerializeField]
    private AudioSource EnvyAudioSource3;

    // 嫉妬のAudioSourceコンポーネント4個目
    [SerializeField]
    private AudioSource EnvyAudioSource4;

    // 嫉妬のAudioSourceコンポーネント(エラー音)
    [SerializeField]
    private AudioSource EnvyAudioSourceError;

    // 嫉妬のゲームオブジェクト
    [SerializeField]
    private GameObject EnvyGameObject;

    // 怠惰のAudioSourceコンポーネント(寝息)
    [SerializeField]
    private AudioSource SlothAudioSource;

    // 怠惰のAudioSourceコンポーネント(時計の音)
    [SerializeField]
    private AudioSource SlothTimerAudioSource;

    // 怠惰のゲームオブジェクト
    [SerializeField]
    private GameObject SlothGameObject;

    // 強欲のAudioSourceコンポーネント(赤い目を引いた時に使う)
    [SerializeField]
    private AudioSource GreedStartAudioSource;

    // 強欲のAudioSourceコンポーネント(コインを5枚渡したときに使う)
    [SerializeField]
    private AudioSource GreedCoinPresentSource;

    // 強欲のAudioSourceコンポーネント(コインを獲得したときに使う)
    [SerializeField]
    private AudioSource GreedCoinGetSource;

    // 色欲のAudioSourceコンポーネント
    [SerializeField]
    private AudioSource LustAudioSource;

    //憤怒の檻を直すときのSE再生
    [SerializeField]
    private AudioSource PrisonRepairAudioSource;

    //暴食への配給時のSE再生
    [SerializeField]
    private AudioSource IssuanceAudioSource;

    //怠惰の檻のボタンを押したときのSE再生
    [SerializeField]
    private AudioSource TimerRepairAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            PCAudionActive = true;
            GluttonyAudionActive = false;
            GluttonyAudioPlayTime = 4.0f;
            PCAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GluttonyAudioManager();
        EnvyAudioManager();
        SlothAudioManager();
    }

    // PCのSEのActive切り替え
    public void PCAudioActiveChange ()
    {
        PCAudionActive = !PCAudionActive;
        if (PCAudionActive)
        {
            PCAudioSource.Play();
        }
        else
        {
            PCAudioSource.Stop();
        }
    }

    // 暴食のSEを再生する関数
    public void GluttonyAudioPlay ()
    {
        GluttonyAudioSource.PlayOneShot(GluttonyAudioClip);
        GluttonyAudionActive = true;
    }

    // 暴食のSEの再生を管理する関数
    private void GluttonyAudioManager ()
    {
        if (GluttonyAudionActive)
        {
            GluttonyAudioPlayTime -= Time.deltaTime;
        }

        if (GluttonyAudioPlayTime <= 0)
        {
            GluttonyAudioSource.Stop();
            GluttonyAudioPlayTime = 4.0f;
            GluttonyAudionActive = false;
        }
    }

    // 憤怒のSEを再生する関数
    public void AngerAudioPlay()
    {
        GluttonyAudioSource.PlayOneShot(AngerAudioClip);
    }

    // 嫉妬のSEの再生を管理する関数
    private void EnvyAudioManager ()
    {
        if (EnvyGameObject.GetComponent<EnvyManager>().EnvyUIActiveResult)
        {
            if (EnvyAudioSource1.isPlaying == false)
            {
                EnvyAudioSource1.Play();
                EnvyAudioSource2.Play();
                EnvyAudioSource3.Play();
                EnvyAudioSource4.Play();
                EnvyAudioSourceError.Play();
            }
        }
        else
        {
            EnvyAudioSource1.Stop();
            EnvyAudioSource2.Stop();
            EnvyAudioSource3.Stop();
            EnvyAudioSource4.Stop();
            EnvyAudioSourceError.Stop();
        }
    }

    // 怠惰のSEの再生を管理する関数
    private void SlothAudioManager ()
    {
        if (SlothGameObject.GetComponent<SlothManager>().TimeStopFragResult)
        {
            if (SlothAudioSource.isPlaying == false)
            {
                SlothAudioSource.Play();
                SlothTimerAudioSource.Play();
            }
        }
        else
        {
            SlothAudioSource.Stop();
            SlothTimerAudioSource.Stop();
        }
    }

    // 強欲のSE(赤い目を引いた時)の再生を管理する関数
    public void GreedStartAudioPlay ()
    {
        GreedStartAudioSource.Play();
    }

    // 強欲のSE(コインを5枚渡した時)の再生を管理する関数
    public void GreedCoinPresentAudioPlay()
    {
        GreedCoinPresentSource.Play();
    }

    // 強欲のSE(コインを獲得した時)の再生を管理する関数
    public void GreedCoinGetAudioPlay()
    {
        GreedCoinGetSource.Play();
    }

    //色欲の赤い目時のSEを再生
    public void LustAudioPlay()
    {

        LustAudioSource.Play();
    }

    //ボタンが押された際に鳴らす檻修繕時SEを再生
    public void PrisonRepairPlay()
    {

        //音がなってなかったら鳴らす
        if (PrisonRepairAudioSource.isPlaying == false)
        {
            //音鳴らす
            PrisonRepairAudioSource.Play();
        }

        //音が鳴ってたら
        else
        {

            //音止める
            PrisonRepairAudioSource.Stop();
        }
    }

    //暴食檻のボタンを押したときのSEを再生
    public void IssuancePlay()
    {

        //音鳴らす
        IssuanceAudioSource.Play();
    }

    public void TimeRepairPlay()
    {

       TimerRepairAudioSource.Play();
    }

    public void TimeRepairStop()
    {

       TimerRepairAudioSource.Stop();
    }
}
