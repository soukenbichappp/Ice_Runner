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
        _rankingText.text = $"ÇPà ÅF{GameManager._ranking[5]}\n" +
                            $"ÇQà ÅF{GameManager._ranking[4]}\n" +
                            $"ÇRà ÅF{GameManager._ranking[3]}\n" +
                            $"ÇSà ÅF{GameManager._ranking[2]}\n" +
                            $"ÇTà ÅF{GameManager._ranking[1]}\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
