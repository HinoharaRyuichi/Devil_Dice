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

    // ���~�̃R�C��UI
    [SerializeField]
    private GameObject GreedCoinUI;

    // ���~�̃R�C��UI��Active
    private bool GreedCoinUIActive;

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

    // �F�~�̎��l
    [SerializeField]
    private GameObject LustPrisoner;

    //�T������t�@�C��
    const string DIR_IMAGES = "Coin";

    //�A�^�b�`����Ă���I�u�W�F
    Image m_SpriteRenderer;

    // �R�C���̉摜�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject CoinImage;

    //�X�v���C�g
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

        m_SpriteRenderer.sprite = m_Sprites[GreedCoinNum];
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

    // ���~�̎��l�ɃR�C����5���n���֐�
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
