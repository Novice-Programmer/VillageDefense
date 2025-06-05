using System.Collections.Generic;
using UnityEngine;

public class WayPointData
{
    public Vector3 StartPosition;
    public List<Vector3> WayPointPositions;

    public WayPointData(Vector3 startPosition, List<Vector3> wayPointPositions)
    {
        StartPosition = startPosition;
        WayPointPositions = wayPointPositions;
    }
}
