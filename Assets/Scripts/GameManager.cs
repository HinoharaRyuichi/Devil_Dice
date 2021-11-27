using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Gulltony�ɂ���ăQ�[���I�[�o�[�ɂȂ����ۂɕ\������摜
    private GameObject gulltonyImage;

    // Anger�ɂ���ăQ�[���I�[�o�[�ɂȂ����ۂɕ\������摜
    private GameObject angerImage;

    // Greed�ɂ���ăQ�[���I�[�o�[�ɂȂ����ۂɕ\������摜
    private GameObject greedImage;

    // GameClear�ɂȂ������ɕ\������摜
    private GameObject gameClear;

    // Window��ς����ۂɈ�u�����\�������摜
    private GameObject windowChange;

    // windowChange��Active
    private bool windowChangeActive;

    // ��L�̉摜��\�����鎞��
    private float WindowChangeWaitTime;

    // ���l�Ǘ��̃Q�[���I�u�W�F�N�g�𓮂����Ă��邩
    private bool PrisonerActionOver;

    // ���l�Ǘ��̃Q�[���I�u�W�F�N�g�𓮂����Ă��邩
    private bool PrisonerActionClear;

    // ��ʑJ�ڂ܂ł̑ҋ@����
    private float GameSceneChangeTime;

    // �ŏ��Ɏʂ������J����
    [SerializeField]
    private GameObject FirstCamera;

    private void Awake()
    {
        // �����ݒ�
        Screen.SetResolution(1920, 1080, true);
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            gulltonyImage = GameObject.Find("GulltonyGameOver");
            angerImage = GameObject.Find("AngerGameOver");
            greedImage = GameObject.Find("GreedGameOver");
            gulltonyImage.SetActive(false);
            angerImage.SetActive(false);
            greedImage.SetActive(false);
            // GameOverWaitTime = 3.0f;
            gameClear = GameObject.Find("GameClear");
            gameClear.SetActive(false);
            // GameClearWaitTime = 3.0f;
            windowChange = GameObject.Find("WindowChange");
            windowChangeActive = false;
            windowChange.SetActive(windowChangeActive);
            WindowChangeWaitTime = 0.5f;
            PrisonerActionOver = true;
            PrisonerActionClear = true;
            GameSceneChangeTime = 4.0f;
            FirstCamera.GetComponent<CinemachineVirtualCamera>().MoveToTopOfPrioritySubqueue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (windowChangeActive)
        {
            WindowChangeWaitTime -= Time.deltaTime;
            if (WindowChangeWaitTime <= 0)
            {
                WindowChangeWaitTime = 0.5f;
                WindowChange();
            }
        }

        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            if (!PrisonerActionOver)
            {
                GameSceneChangeTime -= Time.deltaTime;
                if (Input.GetMouseButton(0) && GameSceneChangeTime <= 0)
                {
                    ChangeScene("GameOver");
                }
            }

            if (!PrisonerActionClear)
            {
                GameSceneChangeTime -= Time.deltaTime;
                if (Input.GetMouseButton(0) && GameSceneChangeTime <= 0)
                {
                    ChangeScene("GameClear");
                }
            }
        }
    }
    
    // �V�[���؂�ւ��p�̊֐�
    public void ChangeScene(string nextScene)
    {

        //�V�[���؂�ւ�
        SceneManager.LoadScene(nextScene);
    }

    // GameOver���ɌĂ΂��֐�
    public void GameOver (string death)
    {
        GameObject.Find("PrisonerManager").SetActive(false);
        GameObject.Find("PrisonerAction").SetActive(false);
        GameObject.Find("TimerRender").SetActive(false);
        switch (death)
        {
            // �\�H�ɂ���āZ���ꂽ��
            case "Gluttony":
                Debug.Log("Gluttony death");
                gulltonyImage.SetActive(true);
                break;
            // ���{�ɂ���āZ���ꂽ��
            case "Anger":
                Debug.Log("Anger death");
                angerImage.SetActive(true);
                break;
            // ���~�ɂ���āZ���ꂽ��
            case "Greed":
                Debug.Log("Greed death");
                greedImage.SetActive(true);
                break;
            default:
                break;
        }

        PrisonerActionOver = false;
    }

    // GameClear���ɌĂ΂��֐�
    public void GameClear ()
    {
        GameObject.Find("PrisonerManager").SetActive(false);
        GameObject.Find("PrisonerAction").SetActive(false);
        GameObject.Find("TimerRender").SetActive(false);

        Debug.Log("Game Clear");
        gameClear.SetActive(true);

        PrisonerActionClear = false;
    }

    public void WindowChange ()
    {
        windowChangeActive = !windowChangeActive;
        if (windowChangeActive)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().CameraChangeAudioResult.Play();
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().CameraChangeAudioResult.Stop();
        }
        
        windowChange.SetActive(windowChangeActive);
    }
}
