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
        // プレイヤーに当たった時の処理
        if (collision.CompareTag("Player"))
        {
            // スコアを加算する
            GameManager.instance.AddScore(10);
            // 自身を消す
            Destroy(this.gameObject);
        }
    }
}
