using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBlink : MonoBehaviour
{

    // ボタンのコンポーネント
    Button Title_text_start;

    // カウンタ
    int cnt;

    // 点滅の速さを設定(60の場合，30フレームごとに色が変わる)
    public int MAX_COUNT = 60;

    // 点滅色の設定
    public List<Color> colors = new List<Color>() { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };


    // Start is called before the first frame update
    void Start()
    {
        //ボタンのコンポーネントを設定
        Title_text_start = GetComponent<Button>();
        //カウンタの初期値を0に設定
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;
        cnt %= MAX_COUNT;
        var cls = Title_text_start.colors;
        cls.normalColor = colors[cnt / (MAX_COUNT / colors.Count)];
        Title_text_start.colors = cls;
    }
}