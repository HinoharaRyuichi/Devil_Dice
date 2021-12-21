using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustManager : MonoBehaviour
{
    // LustGageHideImage�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject LustGageHideImage1;
    [SerializeField]
    private GameObject LustGageHideImage2;

    // LustCircleHideImage�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject LustCircleHideImage;

    // �Ԃ��ڂ��������ۂɉB�������摜(CageGage)
    [SerializeField]
    private GameObject CageGage;

    // �Ԃ��ڂ��������ۂɉB�������摜(Panel)
    [SerializeField]
    private GameObject Panel;

    // �Ԃ��ڂ��������ۂɉB�������摜(SlothCircle)
    [SerializeField]
    private GameObject SlothCircle;

    // �摜���B�������f���邽�߂̃t���O
    private bool HideFrag;

    public bool HideFragResult
    {
        get { return this.HideFrag; }
        set { this.HideFrag = value; }
    }

    // �摜���B������
    private float HideTime;

    // Start is called before the first frame update
    void Start()
    {
        LustGageHideImage1.SetActive(false);
        LustGageHideImage2.SetActive(false);
        LustCircleHideImage.SetActive(false);
        HideFrag = false;
        HideTime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // timeScale��0�Ȃ炻�̌�̏��������Ȃ�
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (HideFrag)
        {

            if (HideTime < 0)
            {

                HideFrag = false;
                HideTime = 10.0f;
                LustCircleHideImage.SetActive(false);
                LustGageHideImage1.SetActive(false);
                LustGageHideImage2.SetActive(false);
            }
            else
            {

                if (CageGage.activeSelf == false && Panel.activeSelf == false)
                {
                    LustGageHideImage1.SetActive(false);
                    LustGageHideImage2.SetActive(false);
                }
                else
                {
                    LustGageHideImage1.SetActive(true);
                    LustGageHideImage2.SetActive(true);
                }

                if (SlothCircle.activeSelf == true)
                {
                    LustCircleHideImage.SetActive(true);
                }
                else
                {
                    LustCircleHideImage.SetActive(false);
                }

                HideTime -= Time.deltaTime;
            }
        }
    }
}
