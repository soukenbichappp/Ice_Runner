using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private float _enemySpeed;
    [SerializeField, Header("最初の位置")] private Transform _startTarget;
    [SerializeField, Header("２つめの位置")] private Transform _firstTarget;
    [SerializeField, Header("３つめの位置")] private Transform _secondTarget;
    [SerializeField, Header("最後の位置")] private Transform _endTarget;
    private bool _startTatgetMove;
    private bool _firstTargetMove;
    private bool _secondTargetMove;
    private bool _endTargetMove;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        _startTatgetMove = false;
        _firstTargetMove = true;
        _secondTargetMove = false;
        _endTargetMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (_startTatgetMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _startTarget.position)
            {
                _startTatgetMove = false;
                _firstTargetMove = true;
            }
        }
        else if (_firstTargetMove && _firstTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _firstTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _firstTarget.position)
            {
                _firstTargetMove = false;
                _secondTargetMove = true;
            } 
        }
        else if (_secondTargetMove && _secondTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _secondTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _secondTarget.position)
            {
                _secondTargetMove = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _endTarget.position, _enemySpeed * Time.deltaTime);
            if (transform.position == _endTarget.position)
            {
                _startTatgetMove = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Shockwave"))
        {
            GameManager.instance.AddScore(10000);
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Player"))
        {           
            _sceneLoader.LoadResultScene();
        }
    }

}
