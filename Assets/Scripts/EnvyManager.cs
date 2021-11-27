using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvyManager : MonoBehaviour
{
    // EnvyUIのActive
    private bool EnvyUIActive;

    // EnvyUIの表示時間
    private float EnvyUITime;

    // EnvyUIのGameObject
    private GameObject envyUI;

    // EnvyUIのActive引き渡し用ゲッタセッタ
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

    // EnvyUIのActive切り替え
    public void EnvyUIActiveChange ()
    {
        EnvyUIActive = !EnvyUIActive;
        envyUI.SetActive(EnvyUIActive);
    }
}
