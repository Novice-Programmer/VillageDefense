using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class WaveData
{
    public float WaveWaitTime;
    public List<SpawnData> SpawnDatas;
}

public class GameWaveData
{
    public float WaveWaitTime;
    public List<GameSpawnData> SpawnDatas;

    public GameWaveData()
    {

    }

    public GameWaveData(WaveData waveData)
    {
        WaveWaitTime = waveData.WaveWaitTime;
        SpawnDatas = waveData.SpawnDatas.Select(v => new GameSpawnData(v)).ToList();
    }

    public GameWaveData Copy()
    {
        return new()
        {
            WaveWaitTime = this.WaveWaitTime,
            SpawnDatas = this.SpawnDatas.Select(v => v.Copy()).ToList()
        };
    }
}