using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustManager : MonoBehaviour
{
    // LustGageHideImage�̃Q�[���I�u�W�F�N�g
    [SerializeField]
    private GameObject LustGageHideImage;

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
        LustGageHideImage.SetActive(false);
        LustCircleHideImage.SetActive(false);
        HideFrag = false;
        HideTime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (HideFrag)
        {
            if (HideTime > 0)
            {

                if (CageGage.activeSelf == false && Panel.activeSelf == false)
                {
                    LustGageHideImage.SetActive(false);
                } else
                {
                    LustGageHideImage.SetActive(true);
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
            else
            {
                HideFrag = false;
                HideTime = 10.0f;
                LustCircleHideImage.SetActive(false);
                LustGageHideImage.SetActive(false);
            }
        }
    }
}
