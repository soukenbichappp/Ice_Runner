using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _playBackButton;
    
    public static List<float> _ranking = new List<float>(6) { 0, 0, 0, 0, 0, 0};
    public static GameManager instance = null;
    public static int _score = 0;
    public static int i;
    public bool screenShakingEffect = true;

    private void Awake()
    {
        // シングルトン
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

    /// <summary>
    /// ランキングとスコアを比較する
    /// </summary>
    public void ScoreJudge()
    {
        for (i = 5;  i < _ranking.Count; i--)
        {
            if (_ranking[i] < _score)
            {
                for (int j = 0; j < i; j++)
                {
                    _ranking[j] = _ranking[j + 1]; 
                }
                _ranking[i] = _score;
                _ranking[0] = 0;
                break;
            }
        }
    }

    public void SetObject()
    {
        _score = 0;
    }

    public void AddScore(int _scoreAmount)
    {
        // ���Z����X�R�A��擾���ĉ��Z
        _score += _scoreAmount;
        if(_scoreText == null)
        {
            _scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<TextMeshProUGUI>();
        }
        // �X�R�A�e�L�X�g��X�V
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
