using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _gameScene;
    [SerializeField] private string _resultScene;
    [SerializeField] private string _titleScene;
    [SerializeField] private string _settingScene;

#if UNITY_EDITOR
    [SerializeField, Header("ゲームシーン")] private SceneAsset _gameSceneAsset;
    [SerializeField, Header("リザルトシーン")] private SceneAsset _resultSceneAsset;
    [SerializeField, Header("タイトルシーン")] private SceneAsset _titleSceneAsset;
    [SerializeField, Header("設定シーン")] private SceneAsset _settingSceneAsset;
#endif
    public void LoadGameScene()
    {
        //　GameSceneを読み込むときの処理
        GameManager.instance.SetObject();
        SoundManager.instance.SetBGM(2);
        SceneManager.LoadScene(_gameScene);
    }

    public void LoadResultScene()
    {
        //　ResultSceneを読み込むときの処理
        GameManager.instance.ScoreJudge();
        SoundManager.instance.SetBGM(3);
        SceneManager.LoadScene(_resultScene);
    }

    public void LoadTitleScene()
    {
        //　TitleSceneを読み込むときの処理
        GameManager.instance.SetObject();
        SoundManager.instance.SetBGM(1);
        SceneManager.LoadScene(_titleScene);
    }

    public void LoadSettingScene()
    {
        //　SettingSceneを読み込むときの処理
        SceneManager.LoadScene(_settingScene);
    }

    public void LoadRunKingScene()
    {
        //　RunKingSceneを読み込むときの処理
        SceneManager.LoadScene(_resultScene);
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

        if (_settingSceneAsset != null)
        {
            _settingScene = _settingSceneAsset.name;
        }
        else
        {
            _settingScene = "";
        }
    }
#endif


}
