using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleCollection", menuName = "Scriptable Objects/Collection/CircleCollection")]
public class CircleCollection : ScriptableObject
{
    public List<CircleData> CircleDatas;
}
