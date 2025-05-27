using System.Collections.Generic;
using System.Linq;

public class GameStageData
{
    public int Index;
    public string VillageName;
    public string Description;
    public string ImageAddressableKey;
    public string MapAddressableKey;
    public float StageWaitTime;
    public List<GameWaveData> WaveDatas;

    public GameStageData()
    {

    }

    public GameStageData(StageData stageData)
    {
        Index = stageData.Index;
        VillageName = stageData.VillageName;
        Description = stageData.Description;
        ImageAddressableKey = stageData.ImageAddressableKey;
        MapAddressableKey = stageData.MapAddressableKey;
        StageWaitTime = stageData.StageWaitTime;
        WaveDatas = stageData.WaveDatas.Select(v => new GameWaveData(v)).ToList();
    }

    public GameStageData Copy()
    {
        return new()
        {
            Index = this.Index,
            VillageName = this.VillageName,
            Description = this.Description,
            ImageAddressableKey = this.ImageAddressableKey,
            MapAddressableKey = this.MapAddressableKey,
            StageWaitTime = this.StageWaitTime,
            WaveDatas = this.WaveDatas.Select(v => v.Copy()).ToList(),
        };
    }
}