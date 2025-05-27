using Cysharp.Threading.Tasks;

public class StageManager : Singletone<StageManager>
{
    private int CurrentStageIndex;

    public async UniTask InitStage_UniTask(int stageIndex)
    {
        if (!DataManager.Instance.GetStageData(stageIndex, out var stageData))
        {
            return;
        }

        CurrentStageIndex = stageIndex;

        await MapManager.Instance.CreateMap(stageData.MapAddressableKey);

        ////스테이지UI매니저.진행중인스테이지UI업데이트(GameManager.Instance.선택된스테이지번호_int);

        ////스테이지초기화();
        //웨이브컨트롤러.웨이브컨트롤러초기화();
        //웨이브컨트롤러.웨이브설정(스테이지_Data.웨이브Data_List);
        //웨이브컨트롤러.웨이브시작();
    }
}
