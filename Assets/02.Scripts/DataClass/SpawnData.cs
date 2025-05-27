using System;

[Serializable]
public class SpawnData
{
    public int WayPointIndex;
    public int SpawnCount;
    public float SpawnWaitTime;
    public EnemyData EnemyData;
}

public class GameSpawnData
{
    public int WayPointIndex;
    public int SpawnCount;
    public float SpawnWaitTime;
    public GameEnemyData EnemyData;

    public GameSpawnData()
    {

    }

    public GameSpawnData(SpawnData spawnData)
    {
        WayPointIndex = spawnData.WayPointIndex;
        SpawnCount = spawnData.SpawnCount;
        SpawnWaitTime = spawnData.SpawnWaitTime;
        EnemyData = new(spawnData.EnemyData);
    }

    public GameSpawnData Copy()
    {
        return new()
        {
            WayPointIndex = this.WayPointIndex,
            SpawnCount = this.SpawnCount,
            SpawnWaitTime = this.SpawnWaitTime,
            EnemyData = this.EnemyData.Copy(),
        };
    }
}