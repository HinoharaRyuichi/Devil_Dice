using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustManager : MonoBehaviour
{
    // LustGageHideImageのゲームオブジェクト
    [SerializeField]
    private GameObject LustGageHideImage1;
    [SerializeField]
    private GameObject LustGageHideImage2;

    // LustCircleHideImageのゲームオブジェクト
    [SerializeField]
    private GameObject LustCircleHideImage;

    // 赤い目を引いた際に隠したい画像(CageGage)
    [SerializeField]
    private GameObject CageGage;

    // 赤い目を引いた際に隠したい画像(Panel)
    [SerializeField]
    private GameObject Panel;

    // 赤い目を引いた際に隠したい画像(SlothCircle)
    [SerializeField]
    private GameObject SlothCircle;

    // 画像を隠すか判断するためのフラグ
    private bool HideFrag;

    public bool HideFragResult
    {
        get { return this.HideFrag; }
        set { this.HideFrag = value; }
    }

    // 画像を隠す時間
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
        // timeScaleが0ならその後の処理をしない
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
