using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeedStack : MonoBehaviour
{
    // �a�X�^�b�N�v���n�u
    [SerializeField]
    private GameObject FeedstackObj;

    // feedStackUI�̃X�N���v�g
    public GameObject feedStackUI;

    // Start is called before the first frame update
    void Start()
    {
        // �V�[�����ɒP���day���܂ރV�[���ł̂ݍs������
        if (SceneManager.GetActiveScene().name.Contains("day"))
        {
            feedStackUI = GameObject.Find("Panel");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    // �a�X�^�b�N�S�폜�������l���쐬
    public void SetFeedStack(int life)
    {
        // �a�X�^�b�N����U�S�폜
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        // ���݂̉a�X�^�b�N�����̃��C�t�Q�[�W���쐬
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(FeedstackObj, transform);
        }
    }
    // �H���̏�������폜
    public void EatFeedStack (int consumption)
    {
        for (int i = 0; i < consumption; i++)
        {
            // �Ō�̃��C�t�Q�[�W���폜
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
