using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //�A�j���[�^���擾
    Animator animetor;

    //�u���p����
    private int Ran;

    // Start is called before the first frame update
    void Start()
    {

        //������
        Ran = 0;

        //�擾
        this.animetor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //�u���p�����擾
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
