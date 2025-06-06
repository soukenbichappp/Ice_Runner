using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask stageLayer;
    [SerializeField] private GameObject shockWave;
    [SerializeField] private Transform attackCircle;
    [SerializeField] private Animator _animation;
    public SceneLoader _sceneLoder;
    private Rigidbody2D rb;
    private float speed = 1.0f;
    private float BACE_SPEED;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    //?øΩ?øΩ?øΩ?øΩ?øΩp
    private float xSpeed = 1.0f;
    private float ySpeed = 1.0f;
    //?øΩ»ÇÔøΩ?øΩ?øΩ?øΩ?øΩ?øΩ?îÇ?øΩ?øΩJ?øΩE?øΩ?øΩ?øΩg?øΩp
    private int counter = 0;
    //?øΩ»ÇÔøΩ?øΩÈèàÔøΩ?øΩ?øΩ…éÔøΩ?øΩs?øΩ?øΩ?øΩ?øΩ?øΩ?øΩ
    private bool isHitWall = false;

    private bool hori = false;
    private bool vart = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shockWave.SetActive(false);
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //?øΩ?øΩ?øΩA?øΩE
            _directionReserve.x = Input.GetAxisRaw("Horizontal");
            //?øΩ?øΩA?øΩ?øΩ
            _directionReserve.y = Input.GetAxisRaw("Vertical");
        }
        if (_directionReserve != Vector2.zero)
        {
            CheckDirection(_directionReserve);
        }
        //?øΩ’åÔøΩ?øΩg?øΩÃîÕàÕÇë¨ìx?øΩ…âÔøΩ?øΩ?øΩ?øΩƒäg?øΩ?øΩ
        attackCircle.localScale = Vector3.one * (1.0f + speed / 3.0f);
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
                if (speed >= 15.0f)
                {
                    shockWave.SetActive(true);
                    Debug.Log("Atack!");
                    StartCoroutine("WaitTime");
                }
                
                Debug.Log("SpeedReset");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            //?øΩ«ê⁄êG?øΩ?øΩ

            // CountTime();

        }
        if (collision.gameObject.tag == "Enemy")
        {
            //?øΩG?øΩ?øΩe?øΩ?øΩ
            Debug.Log("Enemy Hit");
            Debug.Log("End2");
        }

    }

    IEnumerator WaitTime()
    {
        //?øΩ’åÔøΩ?øΩg?øΩ?øΩ?øΩ?øΩ
        
        yield return new WaitForSeconds(0.5f);
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
                    speed *= 1.15f;
                    //?øΩ?øΩ?øΩ?øΩ
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
    private void CountTime()
    {
        float _time = Time.time;
        if (_time <= 1)
        {
            isHitWall = true;
        }
        if (isHitWall == true)
        {
            //speed = 1.0f;
            Debug.Log("SpeedReset");
        }
        _time = 0;
    }
    IEnumerator ShockCool()
    {
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        speed = 1.0f;
    }

}
