using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedStackManager : MonoBehaviour
{
    // �a�X�^�b�N�̐�
    public int feedStackNum;

    // �a�X�^�b�N�̏���l
    int feedStackUpperLimit;

    // �a�X�^�b�N�̌�������
    float FeedTimeOut;

    // feedStack��Active
    bool feedStackUIActive;

    // FeedStack�̃X�N���v�g
    public FeedStack feedStack;

    // GluttonyIcon�̃Q�[���I�u�W�F�N�g
    private GameObject gluttonyIcon;

    // GluttonyIcon�̔�\������
    private float gluttonyIconTime;

    // Start is called before the first frame update
    void Start()
    {
        // ���l�ݒ�
        feedStackNum = 3;
        feedStackUpperLimit = 7;
        FeedTimeOut = 18.0f;

        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            feedStack = GameObject.Find("Panel").GetComponent<FeedStack>();
            gluttonyIcon = GameObject.Find("GluttonyIcon");
            gluttonyIconTime = 5.0f;

            // UI�֘A�̃I�u�W�F�N�g��Active��false�ɕύX
            feedStackUIActive = false;
            feedStack.SetFeedStack(feedStackNum);
            feedStack.feedStackUI.SetActive(feedStackUIActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ��莞�Ԍo�ߌ�ɉa�X�^�b�N��1����
        FeedTimeOut -= Time.deltaTime;
        if (feedStackNum > 0)
        {
            if (FeedTimeOut <= 0)
            {
                feedStack.EatFeedStack(1);
                feedStackNum -= 1;
                GameObject.Find("AudioManager").GetComponent<AudioManager>().GluttonyAudioPlay();
                FeedTimeOut = 14.0f;
            }
        }
        else
        {
            // GameManager��GameOver�֐����Ăяo��
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver("Gluttony");
        }

        if (gluttonyIcon.activeSelf == false)
        {
            gluttonyIconTime -= Time.deltaTime;
            if (gluttonyIconTime <= 0)
            {
                gluttonyIcon.SetActive(true);
                gluttonyIconTime = 5.0f;
            }
        }
    }

    // �}�E�X���N���b�N�������ɌĂяo���֐�
    public void MouseClick()
    {
        // �a�X�^�b�N��0�ȉ��łȂ�
        if (feedStackNum > 0)
        {
            // �a�X�^�b�N������l�����ł���Ȃ�
            if (feedStackNum < feedStackUpperLimit)
            {
                // ���݂̉a�X�^�b�N��1�𑫂�
                feedStack.SetFeedStack(feedStackNum + 1);
                feedStackNum += 1;
                gluttonyIcon.SetActive(false);
            }
        } 
    }

    // feedStackUIActive�̐؂�ւ�
    public void feedStackUIActiveChange()
    {
        feedStackUIActive = !feedStackUIActive;
        feedStack.feedStackUI.SetActive(feedStackUIActive);
    }
}
