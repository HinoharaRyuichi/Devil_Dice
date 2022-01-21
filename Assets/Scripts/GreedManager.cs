using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GreedManager : MonoBehaviour
{
    // GreedCoin�̖���
    private int GreedCoinNum;

    // GreedCoin�̏������
    private int GreedCoinMaxNum;

    // GreedCoin�̏o���t���O
    private bool GreedCoinAppearanceFrag;

    // �ǂ̎��l�̉�ʂɃR�C�����o�������邩
    private int Prisoner;

    // ���{�̎��l
    [SerializeField]
    private GameObject AngerPrisoner;

    // �\�H�̎��l
    [SerializeField]
    private GameObject GluttonyPrisoner;

    // ���i�̎��l
    [SerializeField]
    private GameObject EnvyPrisoner;

    // �ӑĂ̎��l
    [SerializeField]
    private GameObject SlothPrisoner;

    // ���~�̎��l
    [SerializeField]
    private GameObject GreedPrisoner;

    // �F�~�̎��l
    [SerializeField]
    private GameObject LustPrisoner;

    // ���~�̃R�C��UI
    [SerializeField]
    private GameObject GreedCoinUI;

    // ���~�̃R�C��UI��Active
    private bool GreedCoinUIActive;

    // ���{�̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject AngerPrisonCoinEffect;

    // �\�H�̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject GluttonyPrisonCoinEffect;

    // ���i�̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject EnvyPrisonCoinEffect;

    // �ӑĂ̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject SlothPrisonCoinEffect;

    // ���~�̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject GreedPrisonCoinEffect;

    // �F�~�̟B�ɃR�C��������Ƃ��̃G�t�F�N�g
    [SerializeField]
    private GameObject LustPrisonCoinEffect;

    // GreedPrisoner�𓮂������̃t���O
    private bool GreedPrisonerFrag;

    // GreedPrisoner�̃t���O�p�Q�b�^�[
    public bool GreedPrisonerFragResult
    {
        get { return this.GreedPrisonerFrag; }
    }

    // �Q�[���I�[�o�[�ɂȂ�܂ł̐�������
    private float GreedGameOverWaitTime;

    // ���~��Icon�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject GreedIcon;

    // ���~��Icon��Active
    //private bool GreedIconActive;

    //�T������t�@�C��
    const string DIR_COIN_IMAGES = "Coin";

    //�A�^�b�`����Ă���I�u�W�F
    private Image m_CoinImage;

    // �R�C���̉摜�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject CoinImage;

    //�X�v���C�g
    public Sprite[] m_CoinSprites;

    //�摜�̍ő吔
    public int LampIndex = 0;

    //�T������t�@�C��
    const string DIR_LAMP_IMAGES = "Lamp";

    // Image �R���|�[�l���g���i�[����ϐ�
    private Image m_LampImage;

    // �R�C���̉摜�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject LampImage;

    //�X�v���C�g
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
        // timeScale��0�Ȃ炻�̌�̏��������Ȃ�
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

        //�\������摜��ؑ�
        m_LampImage.sprite = m_LampSprites[LampIndex];

        m_CoinImage.sprite = m_CoinSprites[GreedCoinNum];
    }

    // ���~�R�C���o������֐�
    public void GreedCoinAppearance ()
    {
        // �ǂ̎��l�̉�ʂɃR�C�����o�������邩�����肷��
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

    // ���~�̃R�C��UI�̕\���̊֐�
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

    // ���~�R�C����1���Q�b�g����֐�
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

    // ���~�̎��l�̃Q�[���I�[�o�[�Ɋւ��邠�ꂱ�������֐�
    public void GreedGameOver ()
    {
        GreedGameOverWaitTime -= Time.deltaTime;

        if (GreedGameOverWaitTime <= 0)
        {
            // GameManager��GameOver�֐����Ăяo��
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Greed");
        }
    }

    // ���~�̎��l�ɃR�C����3���n���֐�
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
    // ���~��Icon��Active�؂�ւ�
    public void GreedIconActiveChange ()
    {
        GreedIconActive = !GreedIconActive;
        GreedIcon.SetActive(GreedIconActive);
    }
    */

    // GreedPrisonerFrag�̐؂�ւ�
    public void GreedPrisonerFragChange ()
    {
        GreedPrisonerFrag = !GreedPrisonerFrag;
    }
}
