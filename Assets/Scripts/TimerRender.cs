using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRender : MonoBehaviour
{
    //���Ԍv��p
    private float time;

    // 1���Ԃ̕b��
    private float hour;

    //�摜�̍ő吔
    private int index = 0;

    //�T������t�@�C��
    const string DIR_IMAGES = "Time";
    //�A�^�b�`����Ă���I�u�W�F
    SpriteRenderer m_SpriteRenderer;

    //�X�v���C�g
    public Sprite[] m_Sprites;

    // �N���A��̃V�[���`�F���W�܂ł̑ҋ@����
    private float changeTime;

    // SlothManager�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject SlothManager;

    // Start is called before the first frame update
    void Start()
    {
        // �����l�ݒ�(�f�o�b�N�p��5��ݒ�)
        // �Q�[�����x���ݒ���o�̍ۂɂ͍Đݒ��Y��Ȃ�����
        hour = 35.0f;
        time = hour * 6;
        changeTime = 0.5f;

        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (SlothManager.activeSelf)
        {
            if (SlothManager.GetComponent<SlothManager>().TimeStopFragResult == false)
            {
                //���Ԃ����炷
                time -= Time.deltaTime;
            }
        }
        else
        {
            //���Ԃ����炷
            time -= Time.deltaTime;
        }
        
        

        //00:00
        if (time / hour >= 5)
        {

            //�\������摜��ݒ�(1)
            index = 0;
        }

        //01:00
        else if (time / hour >= 4)
        {

            //�\������摜��ݒ�(2)
            index = 1;
        }

        //02:00
        else if (time / hour >= 3)
        {

            //�\������摜��ݒ�(3)
            index = 2;
        }

        //03:00
        else if (time / hour >= 2)
        {

            //�\������摜��ݒ�(4)
            index = 3;
        }

        //04:00
        else if (time / hour >= 1)
        {

            //�\������摜��ݒ�(5)
            index = 4;
        }

        //05::00
        else if (time <= hour && time >= 0)
        {

            //�\������摜��ݒ�(5)
            index = 5;
        }

        //06:00
        else
        {
            index = 6;
            if (changeTime >= 0.0f)
            {
                changeTime -= Time.deltaTime;
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().GameClear();
            }
        }

        //�\������摜��ؑ�
        m_SpriteRenderer.sprite = m_Sprites[index];
    }
}
