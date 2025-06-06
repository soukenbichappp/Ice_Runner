using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Player player; �v���C���[������������ǉ�
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _playBackButton;
    public static GameManager instance = null;
    public static int _score = 0;

    private void Awake()
    {
        // �V���O���g��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetObject();
        _pauseButton.SetActive(true);
        _playBackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�G�Ɠ����������̏���
        //if (player.isHit == true)
        //{
        //    GameOver();
        //}
    }

    void GameOver()
    {
        // GameOver����
        // GameOver�A�j���[�V�����������ɓ����
        SceneManager.LoadScene("");
    }

    public void OpenSetting()
    {

    }

    public void SetObject()
    {
        _score = 0;
    }

    public void AddScore(int _scoreAmount)
    {
        // ���Z����X�R�A���擾���ĉ��Z
        _score += _scoreAmount;
        if(_scoreText == null)
        {
            _scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<TextMeshProUGUI>();
        }
        // �X�R�A�e�L�X�g���X�V
        _scoreText.text = $"Score : {_score}";
    }

    public void Pause()
    {
        //_playBackButton.SetActive(true);
        //_pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void PlayBack()
    {
        //_pauseButton.SetActive(true);
        //_playBackButton.SetActive(false);
        Time.timeScale = 1;
    }

}
