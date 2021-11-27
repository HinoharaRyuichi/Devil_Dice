using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackImage : MonoBehaviour
{

    public EnvyManager Envy;

    // ボタンのコンポーネント
    Image black;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        //ボタンのコンポーネントを設定
        black = GetComponent<Image>();

        alpha = 0.0f;

        black.enabled = Envy.EnvyUIActiveResult;
    }

    // Update is called once per frame
    void Update()
    {

        black.enabled = Envy.EnvyUIActiveResult;

        if (black.enabled)
        {

            alpha += 0.1f;

            if (alpha > 1.0f)
            {

                alpha = 0.0f;
            }

        }

        black.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}