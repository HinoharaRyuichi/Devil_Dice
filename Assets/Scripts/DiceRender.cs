using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiceRender : MonoBehaviour
{
    //�Q�b�^�Z�b�^�󂯎��p�ϐ�
    public Dice dice;
    //result
    int r;
    bool f;

    //�摜�̍ő吔
    public int index = 0;

    //�T������t�@�C��
    const string DIR_IMAGES = "dice";

    // Image �R���|�[�l���g���i�[����ϐ�
    private Image m_Image;

    //�X�v���C�g
    public Sprite[] m_Sprites;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve all images in DIR_IMAGES
        m_Sprites = Resources.LoadAll<Sprite>(DIR_IMAGES);
        m_Image = gameObject.GetComponent<Image>();
        m_Image.sprite = m_Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        // timeScale��0�Ȃ炻�̌�̏��������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        //result�ɑ��
        r = dice.Result;

        f = dice.FragResult;

        if (f == true)
        {
            switch (r)
            {

                //1�̖�
                case 1:

                    //�Ԃ�1�̖�
                    index = 0;

                    break;

                //2�̖�
                case 2:

                    if (SceneManager.GetActiveScene().name == "day1" || /*SceneManager.GetActiveScene().name == "day2" ||*/
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day5")
                    {

                        //����2�̖�
                        index = 6;
                    }

                    else
                    {

                        //�Ԃ�2�̖�
                        index = 1;
                    }

                    break;

                //3�̖�
                case 3:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4" || 
                        SceneManager.GetActiveScene().name == "day5")
                    {

                        //����3�̖�
                        index = 7;
                    }

                    else
                    {

                        //�Ԃ�3�̖�
                        index = 2;
                    }

                    break;

                //4�̖�
                case 4:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4" ||
                        SceneManager.GetActiveScene().name == "day5")
                    {

                        //����4�̖�
                        index = 8;
                    }

                    else
                    {

                        //�Ԃ�4�̖�
                        index = 3;
                    }

                    break;

                //5�̖�
                case 5:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4" ||
                        SceneManager.GetActiveScene().name == "day5")
                    {

                        //����5�̖�
                        index = 9;
                    }

                    else
                    {

                        //�Ԃ�5�̖�
                        index = 5;
                    }

                    break;

                //6�̖�
                case 6:

                    if (SceneManager.GetActiveScene().name == "day1" || SceneManager.GetActiveScene().name == "day2" ||
                        SceneManager.GetActiveScene().name == "day3" || SceneManager.GetActiveScene().name == "day4" ||
                        SceneManager.GetActiveScene().name == "day5")
                    {

                        //����6�̖�
                        index = 10;
                    }

                    else
                    {

                        //�Ԃ�6�̖�
                        index = 6;
                    }

                    break;

                default:
                    break;
            }
        }
        //�\������摜��ؑ�
        m_Image.sprite = m_Sprites[index];
    }
}
