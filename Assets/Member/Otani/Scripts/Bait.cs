using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bait : MonoBehaviour
{
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
