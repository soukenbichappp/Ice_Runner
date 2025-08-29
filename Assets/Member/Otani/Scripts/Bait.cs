using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bait : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[�ɓ����������̏���
        if (collision.CompareTag("Player"))
        {
            // �X�R�A����Z����
            GameManager.instance.AddScore(10);
            // ���g�����
            Destroy(this.gameObject);
        }
    }
}
