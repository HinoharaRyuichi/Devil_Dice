using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlothManager : MonoBehaviour
{
    // �ӑẴT�C�N���̉摜
    private Image SlothImage;

    // �T�C�N���̌��݂̒l
    private float SlothCircleValue;

    // �T�C�N���̍ő�l
    private float SlothCircleMaxValue;

    // �T�C�N���̒l�𑝂₷�ۂɎQ�Ƃ����l
    private float SlothCircleSecondValue;

    // �}�E�X�̃{�^�����������Ƃ�true�A�������Ƃ���false�ɂȂ�t���O
    private bool MouseButtonDownFlag;

    // SlothCircleUI��\�����ׂ����ǂ������Ǘ�����ϐ�(true:�\������ false:�\�����Ȃ�)
    private bool SlothCircleShow;

    // SlothCircle��GameObject
    private GameObject SlothCircle;

    // SlothCircleIcon��GameObject
    private GameObject SlothIcon;

    // SlothCircleUI��Active
    private bool SlothCircleUIActive;

    // ���ǂ̉�ʂ����Ă��邩�𔻕ʂ���ϐ�(true�Ȃ�f�t�H���g��ʁAfalse�Ȃ�ӑẲ��)
    private bool CameraShowNow;

    // CameraShowNow�p�Q�b�^�Z�b�^
    public bool CameraShowNowResult
    {
        get { return this.CameraShowNow; }
        set { this.CameraShowNow = value; }
    }

    // ���Ԓ�~�t���O�ϐ�
    private bool TimeStopFrag;

    // TimeStopFrag�p�Q�b�^�Z�b�^
    public bool TimeStopFragResult
    {
        get { return this.TimeStopFrag; }
        set { this.TimeStopFrag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���l�ݒ�
        SlothCircleValue = 0;
        SlothCircleMaxValue = 3000;
        SlothCircleSecondValue = 10;

        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            SlothImage = GameObject.Find("SlothCircle").GetComponent<Image>();
            SlothCircle = GameObject.Find("SlothCircle");
            SlothIcon = GameObject.Find("SlothIcon");
            MouseButtonDownFlag = false;
            SlothCircleShow = false;
            SlothCircleUIActive = false;
            SlothImage.fillAmount = 0;
            SlothCircle.SetActive(SlothCircleUIActive);
            SlothIcon.SetActive(SlothCircleUIActive);
            CameraShowNow = true;
            TimeStopFrag = false;
            Debug.Log("CameraShowNow = " + CameraShowNow);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day") && SlothCircleShow == true)
        {
            if (MouseButtonDownFlag)
            {
                // �{�^���������Ă���ԃT�C�N���̒l�𑝂₷
                CircleIncrease(SlothCircleSecondValue);
                if (SlothCircleValue >= SlothCircleMaxValue)
                {
                    SlothImage.fillAmount = 0;
                    SlothCircleValue = 0;
                    TimeStopFrag = false;
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PCAudioActiveChange();
                    // SlothCircleShow = false;
                    MouseButtonDownFlag = false;
                    SlothCircleShowChange();
                    SlothCircleActiveChange();
                    CameraShowNow = false;
                }
            }
            else
            {
                // ��ɃT�C�N���̒l��0�ɂ���
                SlothImage.fillAmount = 0;
                SlothCircleValue = 0;
            }
        }
    }

    // �}�E�X�̃{�^�����������Ƃ��̏���
    public void OnButtonDown()
    {
        // �}�E�X�̃{�^���������Ă��邩�̃t���O��true�ɕύX
        MouseButtonDownFlag = true;
    }

    // �}�E�X�̃{�^���𗣂����Ƃ��̏���
    public void OnButtonUp()
    {
        // �}�E�X�̃{�^���������Ă��邩�̃t���O��false�ɕύX
        MouseButtonDownFlag = false;
    }

    // �T�C�N���̒l�𑝂₷�֐�
    public void CircleIncrease(float IncreaseValue)
    {
        var ValueTo = (SlothCircleValue + IncreaseValue) / SlothCircleMaxValue;
        SlothImage.fillAmount = ValueTo;
        // �B�Q�[�W�̃��C�t�̐��l������
        SlothCircleValue += IncreaseValue;
    }

    // SlothCircleUI��Active�؂�ւ�
    public void SlothCircleActiveChange ()
    {
        CameraShowNow = !CameraShowNow;
        Debug.Log("CameraShowNow = " + CameraShowNow);
        if (CameraShowNow)
        {
            SlothCircleUIActive = false;
            SlothCircle.SetActive(SlothCircleUIActive);
            SlothIcon.SetActive(SlothCircleUIActive);
        }
        else
        {
            if (SlothCircleShow)
            {
                SlothCircleUIActive = true;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
            else
            {
                SlothCircleUIActive = false;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
        }
        
    }

    public void SlothCircleShowChange ()
    {
        SlothCircleShow = !SlothCircleShow;
        Debug.Log("SlothCircleShow = " + SlothCircleShow);
        /*if (SlothCircleShow)
        {
            if (CameraShowNow == false)
            {
                SlothCircleUIActive = true;
                SlothCircle.SetActive(SlothCircleUIActive);
                SlothIcon.SetActive(SlothCircleUIActive);
            }
        }*/
    }
}
