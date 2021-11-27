using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExplanationRender : MonoBehaviour
{
    //�Q�b�^�Z�b�^�󂯎��p�ϐ�
    public StageExplanation stageExplanation;
    //result
    int r;
    //�摜�̍ő吔
    public int index = 0;

    //�T������t�@�C��
    const string DIR_IMAGES = "StageExplanation";
    //�A�^�b�`����Ă���I�u�W�F
    SpriteRenderer m_SpriteRenderer;

    //�X�v���C�g
    public Sprite[] m_Sprites;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {

        //result�ɑ��
        r = stageExplanation.Result;

        //�L�[���������Ƃ� �\����ؑ�(�e�X�g
        if (true)
        {

            if (r == 1)
            {

                //�\������摜��ݒ�(1)
                index = 0;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 2)
            {

                //�\������摜��ݒ�(2)
                index = 1;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 3)
            {

                //�\������摜��ݒ�(3)
                index = 2;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 4)
            {

                //�\������摜��ݒ�(4)
                index = 3;
                //Debug.Log("m_index: " + index);
            }

            else if (r == 5)
            {

                //�\������摜��ݒ�(5)
                index = 4;
                //Debug.Log("m_index: " + index);
            }

            else
            {

                //�\������摜��ݒ�(6)
                index = 5;
                //Debug.Log("m_index: " + index);
            }

            //�\������摜��ؑ�
            m_SpriteRenderer.sprite = m_Sprites[index];
        }
    }
}
