using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraX : MonoBehaviour
{
    public Transform player; //プレイヤーのTransform
    public float smoothing = 0.2f; //スムーズな移動のためのスムージング係数

    private Vector3 velocity = Vector3.zero; //スムーズな移動のための速度

    void LateUpdate() //LateUpdateを使用し、プレイヤーの移動後にカメラを移動させる
    {
        if (player != null)
        {
            // カメラの現在の位置
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

            // スムーズな移動
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        }
    }
}
