using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // �\�H��AudioSource�R���|�[�l���g
    [SerializeField]
    private AudioSource GluttonyAudioSource;

    // �\�H��AudioClip�R���|�[�l���g
    [SerializeField]
    private AudioClip GluttonyAudioClip;

    // �\�H��SE��Active
    private bool GluttonyAudionActive;

    // �\�H��SE�̍Đ�����
    private float GluttonyAudioPlayTime;

    // PC��AudioSource�R���|�[�l���g
    [SerializeField]
    private AudioSource PCAudioSource;

    // PC��SE��Active
    private bool PCAudionActive;

    // PC��SE��Active�p�Q�b�^�Z�b�^
    public bool PCAudionActiveResult
    {
        get { return this.PCAudionActive; }
        private set { this.PCAudionActive = value; }
    }

    // ���{��AudioSource�R���|�[�l���g
    [SerializeField]
    private AudioSource AngerAudioSource;

    // ���{��AudioClip�R���|�[�l���g
    [SerializeField]
    private AudioClip AngerAudioClip;

    // �Ď��J������؂�ւ�������SE�̃R���|�[�l���g
    [SerializeField]
    private AudioSource CameraChangeAudioSource;

    public AudioSource CameraChangeAudioResult
    {
        get { return this.CameraChangeAudioSource; }
        private set { this.CameraChangeAudioSource = value; }
    }

    // ���i��AudioSource�R���|�[�l���g1��
    [SerializeField]
    private AudioSource EnvyAudioSource1;

    // ���i��AudioSource�R���|�[�l���g2��
    [SerializeField]
    private AudioSource EnvyAudioSource2;

    // ���i��AudioSource�R���|�[�l���g3��
    [SerializeField]
    private AudioSource EnvyAudioSource3;

    // ���i��AudioSource�R���|�[�l���g4��
    [SerializeField]
    private AudioSource EnvyAudioSource4;

    // ���i��AudioSource�R���|�[�l���g(�G���[��)
    [SerializeField]
    private AudioSource EnvyAudioSourceError;

    // ���i�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject EnvyGameObject;

    // �ӑĂ�AudioSource�R���|�[�l���g(�Q��)
    [SerializeField]
    private AudioSource SlothAudioSource;

    // �ӑĂ�AudioSource�R���|�[�l���g(���v�̉�)
    [SerializeField]
    private AudioSource SlothTimerAudioSource;

    // �ӑẴQ�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject SlothGameObject;

    // ���~��AudioSource�R���|�[�l���g(�Ԃ��ڂ����������Ɏg��)
    [SerializeField]
    private AudioSource GreedStartAudioSource;

    // ���~��AudioSource�R���|�[�l���g(�R�C����5���n�����Ƃ��Ɏg��)
    [SerializeField]
    private AudioSource GreedCoinPresentSource;

    // ���~��AudioSource�R���|�[�l���g(�R�C�����l�������Ƃ��Ɏg��)
    [SerializeField]
    private AudioSource GreedCoinGetSource;

    // �F�~��AudioSource�R���|�[�l���g
    [SerializeField]
    private AudioSource LustAudioSource;

    //���{�̟B�𒼂��Ƃ���SE�Đ�
    [SerializeField]
    private AudioSource PrisonRepairAudioSource;

    //�\�H�ւ̔z������SE�Đ�
    [SerializeField]
    private AudioSource IssuanceAudioSource;

    //�ӑĂ̟B�̃{�^�����������Ƃ���SE�Đ�
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

    // PC��SE��Active�؂�ւ�
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

    // �\�H��SE���Đ�����֐�
    public void GluttonyAudioPlay ()
    {
        GluttonyAudioSource.PlayOneShot(GluttonyAudioClip);
        GluttonyAudionActive = true;
    }

    // �\�H��SE�̍Đ����Ǘ�����֐�
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

    // ���{��SE���Đ�����֐�
    public void AngerAudioPlay()
    {
        GluttonyAudioSource.PlayOneShot(AngerAudioClip);
    }

    // ���i��SE�̍Đ����Ǘ�����֐�
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

    // �ӑĂ�SE�̍Đ����Ǘ�����֐�
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

    // ���~��SE(�Ԃ��ڂ���������)�̍Đ����Ǘ�����֐�
    public void GreedStartAudioPlay ()
    {
        GreedStartAudioSource.Play();
    }

    // ���~��SE(�R�C����5���n������)�̍Đ����Ǘ�����֐�
    public void GreedCoinPresentAudioPlay()
    {
        GreedCoinPresentSource.Play();
    }

    // ���~��SE(�R�C�����l��������)�̍Đ����Ǘ�����֐�
    public void GreedCoinGetAudioPlay()
    {
        GreedCoinGetSource.Play();
    }

    //�F�~�̐Ԃ��ڎ���SE���Đ�
    public void LustAudioPlay()
    {

        LustAudioSource.Play();
    }

    //�{�^���������ꂽ�ۂɖ炷�B�C�U��SE���Đ�
    public void PrisonRepairPlay()
    {

        //�����Ȃ��ĂȂ�������炷
        if (PrisonRepairAudioSource.isPlaying == false)
        {
            //���炷
            PrisonRepairAudioSource.Play();
        }

        //�������Ă���
        else
        {

            //���~�߂�
            PrisonRepairAudioSource.Stop();
        }
    }

    //�\�H�B�̃{�^�����������Ƃ���SE���Đ�
    public void IssuancePlay()
    {

        //���炷
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
