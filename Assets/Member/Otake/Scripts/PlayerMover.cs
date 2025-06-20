using System.Collections;
using UnityEngine;
using Cinemachine;
public class PlayerMover : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private LayerMask stageLayer;
    [SerializeField] private GameObject shockWave;
    [SerializeField] private GameObject shockChage;
    [SerializeField] private Transform attackCircle;
    [SerializeField] private Animator _animation;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private AudioSource shockAudio;
    public SceneLoader _sceneLoder;
    private Rigidbody2D rb;
    private float speed = 1.5f;
    private float BACE_SPEED;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        shockWave.SetActive(false);
        shockChage.SetActive(false);
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //?��?��?��A?��E
            _directionReserve.x = Input.GetAxisRaw("Horizontal");
            //?��?��A?��?��
            _directionReserve.y = Input.GetAxisRaw("Vertical");
            if(_direction.x == 1)
            {
                if(speed >= 8.0f)
                {
                    MainSpriteRenderer.sprite = rightSprite;
                    shockChage.SetActive(true);
                }
                else
                {
                    MainSpriteRenderer.sprite = rightSprite;
                    shockChage.SetActive(false);
                }
            }
            else if(_direction.x == -1)
            {
                if (speed >= 8.0f)
                {
                    MainSpriteRenderer.sprite = leftSprite;
                    shockChage.SetActive(true);
                }
                else
                {
                    MainSpriteRenderer.sprite = leftSprite;
                    shockChage.SetActive(false);
                }
            }
            else if(_direction.y == 1)
            {
                if (speed >= 8.0f)
                {
                    MainSpriteRenderer.sprite = upSprite;
                    shockChage.SetActive(true);
                }
                else
                {
                    MainSpriteRenderer.sprite = upSprite;
                    shockChage.SetActive(false);
                }
            }
            else if (_direction.y == -1)
            {
                if (speed >= 8.0f)
                {
                    MainSpriteRenderer.sprite = downSprite;
                    shockChage.SetActive(true);
                }
                else
                {
                    MainSpriteRenderer.sprite = downSprite;
                    shockChage.SetActive(false);
                }
            }
        }
        if (_directionReserve != Vector2.zero)
        {
            CheckDirection(_directionReserve);
        }
        //?��Ռ�?��g?��͈̔͂𑬓x?��ɉ�?��?��?��Ċg?��?��
        attackCircle.localScale = Vector3.one * (1.0f + speed / 10.0f);
        Vector2 dist = _direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {

            var colliderVec = other.transform.position - transform.position;

            if (Mathf.Abs(colliderVec.x - _direction.x) < 0.3f && Mathf.Abs(colliderVec.y - _direction.y) < 0.3f)
            {
                //
                Debug.Log("Hit");
                Debug.Log($"colliderVec{colliderVec},_direction{_direction}");
                Debug.Log("Map Hit");
                if (speed >= 8.0f)
                {
                    shockWave.SetActive(true);
                    Debug.Log("Atack!");
                    var impulseSouse = GetComponent<CinemachineImpulseSource>();
                    impulseSouse.GenerateImpulse();
                    shockAudio.Play();
                    StartCoroutine("WaitTime");
                }
                speed = 1.5f;
                Debug.Log("SpeedReset");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            //?��ǐڐG?��?��

            // CountTime();

        }
        if (collision.gameObject.tag == "Enemy")
        {
            //?��G?��?��e?��?��
            Debug.Log("Enemy Hit");
            Debug.Log("End2");
        }

    }

    IEnumerator WaitTime()
    {
        //?��Ռ�?��g?��?��?��?��
        
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("ShockCool");
        shockWave.SetActive(false);
        Debug.Log("End");
    }
    private void CheckDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, stageLayer);
        if (hit.collider == null)
        {
            _directionReserve = Vector2.zero;
            if ((direction.x == 0 && direction.y == 0) == false)
            {
                if (_direction != direction)
                {
                    speed *= 1.18f;
                    //?��?��?��?��
                    Debug.Log("kasoku");
                    if (speed >= 50f)
                    {
                        speed = 50f;
                    }
                    Debug.Log(speed);
                }
            }
            _direction = direction;
        }
    }
    IEnumerator ShockCool()
    {
        speed = 0;
        yield return new WaitForSeconds(0.4f);
        speed = 1.5f;
    }

}
