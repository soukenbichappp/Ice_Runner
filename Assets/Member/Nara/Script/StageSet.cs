using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSet : MonoBehaviour
{
    const int StageTipSize = 10;    // 自動生成するステージオブジェクトの端から端までの大きさ
    int currentTipIndex;
    public Transform character;     // ターゲットするキャラクターの指定
    public GameObject[] stageTips;  // ステージチップの配列
    public int startTipIndex;       // 自動生成する時に使う変数
    public int preInstantiate;      // ステージ生成の読み込み個数
    public List<GameObject> generatedStageList = new List<GameObject>();// 作ったステージチップの保持リスト

    // Start is called before the first frame update
    void Start()
    {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex = (int)(character.position.y / StageTipSize);
        // 次のステージチップに入ったらステージの更新処理を行う
        if(charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }

    // 指定のインデックスまでのステージチップを生成して、管理下に置く
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;

        // 指定のステージチップまで生成する
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++) 
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }

        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentTipIndex = toTipIndex;
    }

    // 指定のインデックス位置に stage オブジェクトをランダムに生成
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(3, tipIndex * StageTipSize, 0),
            Quaternion.identity) as GameObject;
        return stageObject;
    }

    
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
