using System.Collections;
using UnityEngine;
using Cinemachine;
public class PlayerMover : MonoBehaviour
{
    private enum WayDirection
    {
        None,
        Up,
        Down,
        Right,
        Left
    }
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] SpriteRenderer ShockChageRenderer;
    [SerializeField] private LayerMask stageLayer;
    [SerializeField] private GameObject shockWave;
    [SerializeField] private GameObject shockChage;
    [SerializeField] private Transform attackCircle;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite shockUpSprite;
    [SerializeField] private Sprite shockDownSprite;
    [SerializeField] private Sprite shockRightSprite;
    [SerializeField] private Sprite shockLeftSprite;
    [SerializeField] private AudioSource shockAudio;
    [SerializeField] private AudioSource shockmissAudio;
    [SerializeField] private GameObject _deathfront;
    [SerializeField] private GameObject _deathback;
    [SerializeField] private GameObject _deathright;
    [SerializeField] private GameObject _deathleft;
    [SerializeField] private float _limitSpeed = 0.01f;
    private Rigidbody2D rb;
    private bool deathflag = false;
    private bool shockflag = true;
    private float speed = 1.77f;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    private Vector2 _way;
    private WayDirection _wayDirection = WayDirection.None;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        shockWave.SetActive(false);
        shockChage.SetActive(false);
        _deathfront.SetActive(false);
        _deathback.SetActive(false);
        _deathleft.SetActive(false);
        _deathright.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //?��?��?��A?��E
            _directionReserve.x = Input.GetAxisRaw("Horizontal");
            //?��?��A?��?��
            _directionReserve.y = Input.GetAxisRaw("Vertical");
        }
        if (_directionReserve != Vector2.zero)
        {
            CheckDirection(_directionReserve);
        }
        //?��Ռ�?��g?��͈̔͂𑬓x?��ɉ�?��?��?��Ċg?��?��
        //attackCircle.localScale = Vector3.one * (1.0f + speed / 10.0f);
        Vector2 dist = _direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if(deathflag == false)
            {
                if (_direction.x == -1)
                {
                    Debug.Log("nyu");
                    speed = 0;
                    if (shockWave.activeSelf is false)
                    {
                        GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                        shockChage.SetActive(false);
                        _deathleft.SetActive(true);
                        deathflag = true;
                    }

                }
                else if (_direction.x == 1)
                {
                    speed = 0;
                    if (shockWave.activeSelf is false)
                    {
                        GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                        shockChage.SetActive(false);
                        _deathright.SetActive(true); 
                        deathflag = true;
                    }
                }
                else if (_direction.y == 1)
                {
                    speed = 0;
                    if (shockWave.activeSelf is false)
                    {
                        GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                        shockChage.SetActive(false);
                        _deathback.SetActive(true);
                        deathflag = true;
                    }
                }
                else if (_direction.y == -1)
                {
                    speed = 0;
                    if (shockWave.activeSelf is false)
                    {
                        GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                        shockChage.SetActive(false);
                        _deathfront.SetActive(true);
                        deathflag = true;
                    }
                }
            }
        }

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
                    if (GameManager.instance.screenshakingeffect == true)
                    {
                        Debug.Log("On");
                        var impulseSouse = GetComponent<CinemachineImpulseSource>();
                        impulseSouse.GenerateImpulse();
                    }
                    shockAudio.Play();
                    StartCoroutine("WaitTime");
                }
                if (speed < 8.0f && speed > 6.0f)
                {Debug.Log(speed);
                    if (shockflag == true)
                    {
                        shockmissAudio.Play();
                        shockflag = false;
                        speed = 1.77f;
                    }
                }
                speed = 1.77f;
                shockflag = true;
                Debug.Log("SpeedReset");
            }
        }
    }
    IEnumerator WaitTime()
    {
        //衝撃波の切り替え
        yield return new WaitForSeconds(0.2f);
        shockChage.SetActive(false);
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
                    UpdateDirection(direction);
                    speed *= 1.18f;
                    //速度上限
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
        speed = 1.77f;
    }

    private void UpdateDirection(Vector2 direction)
    {
        var waydirection = GetWayDirection(direction);
        if (_wayDirection != waydirection)
        {
            //向きを変える
            switch (waydirection)
            {
                case WayDirection.Up:
                    if (speed >= 7.8f)
                    {
                        MainSpriteRenderer.sprite = upSprite;
                        ShockChageRenderer.sprite = shockUpSprite;
                        shockChage.SetActive(true);
                    }
                    else
                    {
                        MainSpriteRenderer.sprite = upSprite;
                        shockChage.SetActive(false);
                    }
                    break;
                case WayDirection.Down:
                    if (speed >= 7.8f)
                    {
                        MainSpriteRenderer.sprite = downSprite;
                        ShockChageRenderer.sprite = shockDownSprite;
                        shockChage.SetActive(true);
                    }
                    else
                    {
                        MainSpriteRenderer.sprite = downSprite;
                        shockChage.SetActive(false);
                    }
                    break;
                case WayDirection.Right:
                    if (speed >= 7.8f)
                    {
                        MainSpriteRenderer.sprite = rightSprite;
                        ShockChageRenderer.sprite = shockRightSprite;
                        shockChage.SetActive(true);
                    }
                    else
                    {
                        MainSpriteRenderer.sprite = rightSprite;
                        shockChage.SetActive(false);
                    }
                    break;
                case WayDirection.Left:
                    if (speed >= 7.8)
                    {
                        MainSpriteRenderer.sprite = leftSprite;
                        ShockChageRenderer.sprite = shockLeftSprite;
                        shockChage.SetActive(true);
                    }
                    else
                    {
                        MainSpriteRenderer.sprite = leftSprite;
                        shockChage.SetActive(false);
                    }
                    break;
            }
            _wayDirection = waydirection;
        }
    }

    private WayDirection GetWayDirection(Vector2 direction)
    {
        _way.x = Mathf.Abs(direction.x);
        _way.y = Mathf.Abs(direction.y);
        if (_limitSpeed > _way.x && _limitSpeed > _way.y)
        {
            _way.x = 0;
            _way.y = 0;
            return WayDirection.None;
        }
        if (_way.x > _way.y)
        {
            //左右
            if (direction.x > 0)
            {
                return WayDirection.Right;
            }
            return WayDirection.Left;
        }
        else
        {
            //上下
            if (direction.y > 0)
            {
                return WayDirection.Up;
            }
            return WayDirection.Down;
        }
    }
}
