using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustManager : MonoBehaviour
{
    // LustGageHideImage‚ÌƒQ[ƒ€ƒIƒuƒWƒFƒNƒg
    [SerializeField]
    private GameObject LustGageHideImage;

    // LustCircleHideImage‚ÌƒQ[ƒ€ƒIƒuƒWƒFƒNƒg
    [SerializeField]
    private GameObject LustCircleHideImage;

    // Ô‚¢–Ú‚ðˆø‚¢‚½Û‚É‰B‚µ‚½‚¢‰æ‘œ(CageGage)
    [SerializeField]
    private GameObject CageGage;

    // Ô‚¢–Ú‚ðˆø‚¢‚½Û‚É‰B‚µ‚½‚¢‰æ‘œ(Panel)
    [SerializeField]
    private GameObject Panel;

    // Ô‚¢–Ú‚ðˆø‚¢‚½Û‚É‰B‚µ‚½‚¢‰æ‘œ(SlothCircle)
    [SerializeField]
    private GameObject SlothCircle;

    // ‰æ‘œ‚ð‰B‚·‚©”»’f‚·‚é‚½‚ß‚Ìƒtƒ‰ƒO
    private bool HideFrag;

    public bool HideFragResult
    {
        get { return this.HideFrag; }
        set { this.HideFrag = value; }
    }

    // ‰æ‘œ‚ð‰B‚·ŽžŠÔ
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
