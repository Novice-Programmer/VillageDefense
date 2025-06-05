using System;

[Serializable]
public class SpawnData
{
    public int WayPointIndex;
    public int SpawnCount;
    public float SpawnWaitTime;
    public EnemyKeyData EnemyKeyData;
}

public class GameSpawnData
{
    public int WayPointIndex;
    public int SpawnCount;
    public float SpawnWaitTime;
    public EnemyKeyData EnemyKeyData;

    public GameSpawnData()
    {

    }

    public GameSpawnData(SpawnData spawnData)
    {
        WayPointIndex = spawnData.WayPointIndex;
        SpawnCount = spawnData.SpawnCount;
        SpawnWaitTime = spawnData.SpawnWaitTime;
        EnemyKeyData = spawnData.EnemyKeyData;
    }

    public GameSpawnData Copy()
    {
        return new()
        {
            WayPointIndex = this.WayPointIndex,
            SpawnCount = this.SpawnCount,
            SpawnWaitTime = this.SpawnWaitTime,
            EnemyKeyData = this.EnemyKeyData,
        };
    }
}