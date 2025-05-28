using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class StageManager : Singletone<StageManager>
{
    [SerializeField] private MapController MapController;
    [SerializeField] private WaveController WaveController;

    public async UniTask InitStage_UniTask(int stageIndex)
    {
        if (!DataManager.Instance.GetStageData(stageIndex, out var stageData))
        {
            return;
        }

        await MapController.CreateMap(stageData.MapAddressableKey);

        ////스테이지UI매니저.진행중인스테이지UI업데이트(GameManager.Instance.선택된스테이지번호_int);

        ////스테이지초기화();
        //웨이브컨트롤러.웨이브컨트롤러초기화();
        //웨이브컨트롤러.웨이브설정(스테이지_Data.웨이브Data_List);
        //웨이브컨트롤러.웨이브시작();
    }
}
