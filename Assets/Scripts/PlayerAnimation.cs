using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //アニメータを取得
    Animator animetor;

    //瞬き用乱数
    private int Ran;

    // Start is called before the first frame update
    void Start()
    {

        //初期化
        Ran = 0;

        //取得
        this.animetor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //瞬き用乱数取得
        Ran = Random.Range(1, 8);

        if (Ran == 3)
        {

            animetor.SetBool("Frag", true);

            // Debug.Log("true");
        }

        else
        {

            animetor.SetBool("Frag", false);

            // Debug.Log("false");
        }
    }
}
