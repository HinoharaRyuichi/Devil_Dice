using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExplanation : MonoBehaviour
{
    //�X�e�[�W�����|�C���^�����n���p�ϐ�
    private int StageExplanationResult;

    //�o�ڈ����n���p�Q�b�^�Z�b�^
    public int Result
    {

        get { return this.StageExplanationResult; }
        private set { this.StageExplanationResult = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        StageExplanationResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �X�e�[�W�I���ɂ�day1���������摜��\������֐�
    public void Day1Choice ()
    {
        Debug.Log("Day1_Choice");
        StageExplanationResult = 1;
    }

    // �X�e�[�W�I���ɂ�day2���������摜��\������֐�
    public void Day2Choice()
    {
        Debug.Log("Day2_Choice");
        StageExplanationResult = 2;
    }

    // �X�e�[�W�I���ɂ�day3���������摜��\������֐�
    public void Day3Choice()
    {
        Debug.Log("Day3_Choice");
        StageExplanationResult = 3;
    }

    // �X�e�[�W�I���ɂ�day4���������摜��\������֐�
    public void Day4Choice()
    {
        Debug.Log("Day4_Choice");
        StageExplanationResult = 4;
    }

    // �X�e�[�W�I���ɂ�day5���������摜��\������֐�
    public void Day5Choice()
    {
        Debug.Log("Day5_Choice");
        StageExplanationResult = 5;
    }

    // �X�e�[�W�I���ɂăf�t�H���g�摜��\������֐�
    public void DefaultDay()
    {
        Debug.Log("Default");
        StageExplanationResult = 0;
    }
}
