using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _gameScene;
    [SerializeField] private string _rankingScene;
    [SerializeField] private string _resultScene;
    [SerializeField] private string _titleScene;

#if UNITY_EDITOR
    [SerializeField, Header("ゲームシーン選択")] private SceneAsset _gameSceneAsset;
    [SerializeField, Header("ランキングシーン選択")] private SceneAsset _rankingSceneAsset;
    [SerializeField, Header("リザルトシーン選択")] private SceneAsset _resultSceneAsset;
    [SerializeField, Header("タイトルシーン選択")] private SceneAsset _titleSceneAsset;
#endif
    public void LoadGameScene()
    {
        GameManager.instance.SetObject();
        SceneManager.LoadScene(_gameScene);
    }

    public void LoadRankingScene()
    {
        SceneManager.LoadScene(_rankingScene);
    }

    public void LoadResultScene()
    {
        GameManager.instance.ScoreJudge();
        SceneManager.LoadScene(_resultScene);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene(_titleScene);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_gameSceneAsset != null)
        {
            _gameScene = _gameSceneAsset.name;
        }
        else
        {
            _gameScene = "";
        }

        if (_rankingSceneAsset != null)
        {
            _rankingScene = _rankingSceneAsset.name;
        }
        else
        {
            _rankingScene = "";
        }

        if (_resultSceneAsset != null)
        {
            _resultScene = _resultSceneAsset.name;
        }
        else
        {
            _resultScene = "";
        }

        if (_titleSceneAsset != null)
        {
            _titleScene = _titleSceneAsset.name;
        }
        else
        {
            _titleScene = "";
        }
    }
#endif


}
