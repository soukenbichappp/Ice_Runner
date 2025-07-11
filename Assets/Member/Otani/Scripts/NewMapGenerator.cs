using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewMapGenerator : MonoBehaviour
{
    // マップの端から端までのサイズ
    private const float StageTipSize = 20;

    private float _currentTipIndex;

    [SerializeField] private Transform _character; // キャラクターの位置
    [SerializeField] private GameObject[] _stageTips; // 生成するステージ
    [SerializeField] private float _startTipIndex; // 開始するステージのインデックス
    [SerializeField] private float _preInstantiate; // 先読み生成
    [SerializeField] private List<GameObject> generatedStageList = new List<GameObject>();

    private void Start()
    {
        
    }

    private void Update()
    {
        float charPositionIndex = (float)(_character.position.y / StageTipSize);
        // 次のステージチップに入ったらステージの更新処理を行う
        if (charPositionIndex + _preInstantiate > _currentTipIndex)
        {
            UpdateStage(charPositionIndex + _preInstantiate);
        }

    }

    private void UpdateStage(float toTipIndex)
    {
        // 指定のindexが現在のindexより小さければ何もしない
        if (toTipIndex <= _currentTipIndex) return;
        for(int i = (int)_currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i); // ステージを生成
            generatedStageList.Add(stageObject);
        }
        // 保持上限まで
        while (generatedStageList.Count > _preInstantiate + 2) DestroyOldestStage();
        _currentTipIndex = toTipIndex; 
    }

    private GameObject GenerateStage(int tipIndex)
    {
        // ランダムな値のステージを生成
        int nextStageTip = Random.Range(0, _stageTips.Length);

        GameObject stageObject = Instantiate(
            _stageTips[nextStageTip],
            new Vector3(0, tipIndex * StageTipSize, 0),
            Quaternion.identity);
        // 生成したオブジェクトを返す
        return stageObject; 
    }

    private void DestroyOldestStage()
    {
        // リストの先頭を取得
        GameObject oldStage = generatedStageList[0];
        // リストの先頭を削除
        generatedStageList.RemoveAt(0);
        // 取得したオブジェクトを削除
        Destroy(oldStage);
    }
}
