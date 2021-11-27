using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //�T�C�R����]�����܂ł̃N�[���^�C��
    public float DiceTime;
    //2D�e�X�g�p����
    private int Ran;
    //�o�ڈ����n���p�ϐ�
    private int DiceResult;

    // �_�C�X�U�������̃t���O
    private bool DiceFrag;

    //�o�ڈ����n���p�Q�b�^�Z�b�^
    public int Result
    {

        get { return this.DiceResult; }
        private set { this.DiceResult = value; }
    }

    // �_�C�X�U�������̃t���O�p�Q�b�^�Z�b�^
    public bool FragResult
    {

        get { return this.DiceFrag; }
        private set { this.DiceFrag = true; }
    }

    // Start is called before the first frame update
    void Start()
    {

        //�����l5(�e�X�g�̂���)
        DiceTime = 7.0f;
        //������
        DiceResult = 0;

        DiceFrag = false;
    }

    // Update is called once per frame
    void Update()
    {

        //�T�C�R����U��܂ł̎��Ԃ����炷
        DiceTime -= Time.deltaTime;

        //�N�[���^�C����0�ɂȂ����Ƃ�
        if (DiceTime < 0)
        {
            //2D�p����
            Ran = Random.Range(1, 7);

            //�N�[���^�C���������l�ɖ߂�
            DiceTime = 7.0f;

            DiceFrag = true;
        }

        else
        {
            //2D�o�ڂ̊m�F
            if (Ran >= 1 && Ran <= 6)
            {
                DiceResult = Ran;
                DiceFrag = false;
            }
        }
    }
}
