using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rankingText;

    // Start is called before the first frame update
    void Start()
    {
        _rankingText.text = $"�P�ʁF{GameManager._ranking[5]}\n" +
                            $"�Q�ʁF{GameManager._ranking[4]}\n" +
                            $"�R�ʁF{GameManager._ranking[3]}\n" +
                            $"�S�ʁF{GameManager._ranking[2]}\n" +
                            $"�T�ʁF{GameManager._ranking[1]}\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
