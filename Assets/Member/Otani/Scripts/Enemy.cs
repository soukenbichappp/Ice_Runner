using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private float _enemySpeed;
    [SerializeField, Header("最初に移動する位置")] private Transform _startTarget;
    [SerializeField, Header("２番目に移動する位置")] private Transform _firstTarget;
    [SerializeField, Header("３番目に移動する位置")] private Transform _secondTarget;
    [SerializeField, Header("最後に移動する位置")] private Transform _endTarget;
    private Animator _animator;
    private bool _startTatgetMove;
    private bool _firstTargetMove;
    private bool _secondTargetMove;
    private bool _isDead;
    private const int EnemyScore = 100;  

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        _startTatgetMove = false;
        _firstTargetMove = true;
        _secondTargetMove = false;
        _isDead = false;
        _animator = GetComponent<Animator>();
        _animator.SetBool("movefront", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(_startTarget != null && _isDead == false)
        {
            Vector3 pastPosition = transform.position;
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
            if (pastPosition.y > transform.position.y)
            {
                _animator.SetBool("movefront", true);
                _animator.SetBool("moveback", false);
                _animator.SetBool("moveleft", false);
                _animator.SetBool("moveright", false);
            }
            else if (pastPosition.y < transform.position.y)
            {
                _animator.SetBool("movefront", false);
                _animator.SetBool("moveback", true);
                _animator.SetBool("moveleft", false);
                _animator.SetBool("moveright", false);
            }
            else if (pastPosition.x > transform.position.x)
            {
                _animator.SetBool("movefront", false);
                _animator.SetBool("moveback", false);
                _animator.SetBool("moveleft", true);
                _animator.SetBool("moveright", false);
            }
            else if (pastPosition.x < transform.position.x)
            {
                _animator.SetBool("movefront", false);
                _animator.SetBool("moveback", false);
                _animator.SetBool("moveleft", false);
                _animator.SetBool("moveright", true);
            }
        }

    }

    /// <summary>
    /// Enemyが触れた時の処理
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(_startTarget != null)
        {
            //　衝撃波に触れたらスコアを加算して消滅する
            if (collider.gameObject.CompareTag("Shockwave"))
            {
                _isDead = true;
                GameManager.instance.AddScore(EnemyScore);
                gameObject.tag = new string("Untagged");
                _animator.SetBool("isdead", true);
                Invoke("DestroyThisObject", 0.4f);
                
            }
        }

        //　プレイヤーと触れたらリザルトへ移動
        if (collider.CompareTag("Player") && _isDead == false)
        {
            _sceneLoader.Invoke("LoadResultScene", 1.9f);
        }
    }

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }

}
