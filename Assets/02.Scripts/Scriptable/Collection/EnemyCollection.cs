using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCollection", menuName = "Scriptable Objects/Collection/EnemyCollection")]
public class EnemyCollection : ScriptableObject
{
    public List<EnemyData> EnemyDatas;
}
