using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CageGauge : MonoBehaviour
{
    // �B�Q�[�W
    [SerializeField]
    private Image GreenGauge;

    // �}�E�X�̃{�^�����������Ƃ�true�A�������Ƃ���false�ɂȂ�t���O
    private bool MouseButtonDownFlag = false;

    // �B�Q�[�W��HP
    public float CageLife;

    // �B�Q�[�W�̍ő�HP
    public float CageMaxLife;

    // �B�Q�[�W�֖��b�^����_���[�W��
    float secondDamage;

    // �T�C�R���̐Ԃ��ڂ��o���ۂɟB�Q�[�W�ɗ^����_���[�W
    public float damage;

    // �A�C�R���������Ă���Ԃ̟B�Q�[�W�̉񕜗�
    float recovery;

    // cageGaugeUI�X�N���v�g
    //private GameObject cageGaugeUI;

    // cageGauge��Active
    //bool cageGaugeUIActive;

    // ���{�B�{�^�����������Ƃ���SE�悤�t���O�n��
    public bool MouseButtonFrag
    {
        get { return this.MouseButtonDownFlag; }
        private set { this.MouseButtonDownFlag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���l�ݒ�
        CageLife = 1000f;
        CageMaxLife = 1000f;
        secondDamage = 0.5f;
        damage = 100f;
        recovery = 2f;

        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            //cageGaugeUI = GameObject.Find("CageGauge");

            // UI�֘A�̃I�u�W�F�N�g��Active��false�ɕύX
            //cageGaugeUIActive = false;
            //cageGaugeUI.SetActive(cageGaugeUIActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // timeScale��0�Ȃ炻�̌�̏��������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            if (MouseButtonDownFlag)
            {
                // �{�^���������Ă���ԟB�Q�[�W��
                GaugeIncrease(recovery);
            }
            else
            {
                // ��ɟB�Q�[�W������
                GaugeReduction(secondDamage);
            }
        }
    }

    // �B�Q�[�W������������֐�
    public void GaugeReduction(float reducationValue)
    {
        var ValueTo = (CageLife - reducationValue) / CageMaxLife;
        GreenGauge.fillAmount = ValueTo;
        // �B�Q�[�W�̃��C�t�̐��l������
        CageLife -= reducationValue;
        if (CageLife <= 0)
        {
           // GameManager��GameOver�֐����Ăяo��
           GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Anger");
        }
    }

    // �B�Q�[�W�𑝉�����֐�
    public void GaugeIncrease(float IncreaseValue)
    {
        if (CageLife + IncreaseValue < CageMaxLife)
        {
            var ValueTo = (CageLife + IncreaseValue) / CageMaxLife;
            GreenGauge.fillAmount = ValueTo;
            // �B�Q�[�W�̃��C�t�̐��l������
            CageLife += IncreaseValue;
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
        if (MouseButtonDownFlag)
        {
            // �}�E�X�̃{�^���������Ă��邩�̃t���O��false�ɕύX
            MouseButtonDownFlag = false;
        }
    }

    // �}�E�X�̃{�^�����痣�ꂽ�Ƃ��̏���
    public void OnButtonExit ()
    {
        if (MouseButtonDownFlag)
        {
            // �}�E�X�̃{�^���������Ă��邩�̃t���O��false�ɕύX
            MouseButtonDownFlag = false;
        }
    }

    /*
    // cageGaugeUI��Active�؂�ւ�
    public void cageGaugeUIActiveChange()
    {
        cageGaugeUIActive = !cageGaugeUIActive;
        cageGaugeUI.SetActive(cageGaugeUIActive);
    }
    */
}
