using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader1 : MonoBehaviour
{
    public void LoadGameScene()
    {
        GameManager.instance.SetObject();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadRankingScene()
    {
        SceneManager.LoadScene("");
    }

    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
