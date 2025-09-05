using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _rankingTexts;
    [SerializeField] private TextMeshProUGUI _nowScoreText;
    [SerializeField] private float _cycle = 1;

    private double _time;

    // Start is called before the first frame update
    void Start()
    {
        _rankingTexts[4].text = $"１位：{GameManager._ranking[5]}\n";
        _rankingTexts[3].text = $"２位：{GameManager._ranking[4]}\n";
        _rankingTexts[2].text = $"３位：{GameManager._ranking[3]}\n";
        _rankingTexts[1].text = $"４位：{GameManager._ranking[2]}\n";
        _rankingTexts[0].text = $"５位：{GameManager._ranking[1]}\n";

        _nowScoreText.text = $"スコア：{GameManager._score}";

        foreach (var rankingText in _rankingTexts)
        {
            rankingText.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.i != 0 && GameManager._score != 0)
        {
            _rankingTexts[GameManager.i - 1].color = Color.yellow;
            _time += Time.deltaTime;
            float repeatValue = Mathf.Repeat((float)_time, _cycle);
            _rankingTexts[GameManager.i - 1].enabled = repeatValue >= _cycle * 0.5f;
        }
       
    }
}
