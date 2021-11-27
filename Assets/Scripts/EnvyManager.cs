using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvyManager : MonoBehaviour
{
    // EnvyUI��Active
    private bool EnvyUIActive;

    // EnvyUI�̕\������
    private float EnvyUITime;

    // EnvyUI��GameObject
    private GameObject envyUI;

    // EnvyUI��Active�����n���p�Q�b�^�Z�b�^
    public bool EnvyUIActiveResult
    {
        get { return this.EnvyUIActive; }
        private set { this.EnvyUIActive = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            envyUI = GameObject.Find("EnvyUI");

            EnvyUIActive = false;
            EnvyUITime = 4.0f;

            envyUI.SetActive(EnvyUIActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnvyUIActive)
        {
            EnvyUITime -= Time.deltaTime;
            if (EnvyUITime <= 0.0f)
            {
                EnvyUIActiveChange();
                EnvyUITime = 4.0f;
            }
        }
    }

    // EnvyUI��Active�؂�ւ�
    public void EnvyUIActiveChange ()
    {
        EnvyUIActive = !EnvyUIActive;
        envyUI.SetActive(EnvyUIActive);
    }
}
