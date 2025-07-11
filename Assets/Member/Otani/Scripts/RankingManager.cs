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
        _rankingText.text = $"１位{GameManager._ranking[5]}\n" +
                            $"２位{GameManager._ranking[4]}\n" +
                            $"３位{GameManager._ranking[3]}\n" +
                            $"４位{GameManager._ranking[2]}\n" +
                            $"５位{GameManager._ranking[1]}\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
