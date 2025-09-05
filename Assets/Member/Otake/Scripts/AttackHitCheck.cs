using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitCheck : MonoBehaviour
{
    private System.Action<Collider2D> _hitAction;

    public void SetHitCallback(System.Action<Collider2D> hitAction)
    {
        _hitAction = hitAction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            _hitAction?.Invoke(collision);
        }
    }
}
