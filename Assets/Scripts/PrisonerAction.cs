using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrisonerAction : MonoBehaviour
{
    //�Q�b�^�Z�b�^�󂯎��p�ϐ�
    public Dice dice;

    //result
    int r;

    bool f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��莞�Ԃ��ƂɃT�C�R���̖ڂɂ���čs�����邩�𔻒f����
        f = dice.FragResult;

        

        if (f)
        {
            //result�ɑ��
            r = dice.Result;

            // day1�V�[���ł݂̂�肽������
            if (SceneManager.GetActiveScene().name == "day1")
            {
                //result��1�̂Ƃ�
                if (r == 1)
                {

                    Debug.Log("�Ԃ��ڂ��I");

                    //���l�s��
                    Action();
                }
            }

            // day2�V�[���ł݂̂�肽������
            if (SceneManager.GetActiveScene().name == "day2")
            {

                //result��1��2�̂Ƃ�
                if (r == 1 || r == 2)
                {

                    Debug.Log("�Ԃ��ڂ��I");

                    //���l�s��
                    Action();
                }
            }
        }
    }

    // ���l�̍s���֐�
    void Action()
    {
        // �_�C�X�̖��O�ɂ���čs�����ω�
        switch (dice.name)
        {
            // ���{�̍s��
            case "AngerDice":
                CageGauge cageGauge = GameObject.FindObjectOfType<CageGauge>();
                cageGauge.GaugeReduction(cageGauge.damage);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().AngerAudioPlay();
                break;
            // �\�H�̍s��
            case "GluttonyDice":
                FeedStackManager feedStackManager = GameObject.FindObjectOfType<FeedStackManager>();
                if (feedStackManager.feedStackNum > 0)
                {
                    feedStackManager.feedStack.EatFeedStack(1);
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().GluttonyAudioPlay();
                    feedStackManager.feedStackNum -= 1;
                }
                break;
            // ���i�̍s��
            case "EnvyDice":
                GameObject.FindObjectOfType<EnvyManager>().EnvyUIActiveChange();
                break;
            // �ӑĂ̍s��
            case "SlothDice":
                SlothManager slothManager = GameObject.FindObjectOfType<SlothManager>();
                if (slothManager.TimeStopFragResult == false)
                {
                    slothManager.SlothCircleShowChange();
                    slothManager.TimeStopFragResult = true;
                    if (slothManager.CameraShowNowResult == false)
                    {
                        slothManager.CameraShowNowResult = true;
                        slothManager.SlothCircleActiveChange();
                    }
                    // Debug.Log("TimeStopFragResult = " + slothManager.TimeStopFragResult);
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PCAudioActiveChange();
                }
                break;
            // ���~�̍s��
            case "GreedDice":
                GreedManager greedManager = GameObject.FindObjectOfType<GreedManager>();
                if (greedManager.GreedPrisonerFragResult == false)
                {
                    greedManager.GreedPrisonerFragChange();
                    Debug.Log("GreedPrisonerActionStart");
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().GreedStartAudioPlay();
                }
                break;
            // �F�~�̍s��
            case "LustDice":
                break;
            default:
                break;
        }
    }
}

