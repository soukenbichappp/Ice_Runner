using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private SceneLoader1 _sceneLoader;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private Transform _startTarget;
    [SerializeField] private Transform _endTarget;
    private bool _isMove;

    // Start is called before the first frame update
    void Start()
    {
        _isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            // _endTarget.positionへ移動
            transform.position = Vector3.MoveTowards(transform.position, _endTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _endTarget.position)
            {
                _isMove = false;
            }
        }
        else
        {
            // _startTarget.positionへ移動
            transform.position = Vector3.MoveTowards(transform.position, _startTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _startTarget.position)
            {
                _isMove = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Shockwave"))
        {
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Player"))
        {
            _sceneLoader.LoadResultScene();
        }
    }

}
