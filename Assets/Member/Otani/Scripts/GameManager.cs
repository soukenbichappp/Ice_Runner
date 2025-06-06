using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Player player; プレイヤーが完成したら追加
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _playBackButton;
    public static GameManager instance = null;
    public static int _score = 0;

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

    // Update is called once per frame
    void Update()
    {
        //敵と当たった時の処理
        //if (player.isHit == true)
        //{
        //    GameOver();
        //}
    }

    void GameOver()
    {
        // GameOver処理
        // GameOverアニメーションをここに入れる
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
        // 加算するスコアを取得して加算
        _score += _scoreAmount;
        if(_scoreText == null)
        {
            _scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<TextMeshProUGUI>();
        }
        // スコアテキストを更新
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
