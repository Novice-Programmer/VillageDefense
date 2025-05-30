using System.Collections.Generic;
using UnityEngine;

public class WayPointObject : MonoBehaviour
{
    public int Index;

    private Vector3 m_StartPosition;
    private readonly List<Vector3> m_WayPointPositions = new();

    private bool m_IsInit;

    private void InitPosition()
    {
        m_StartPosition = transform.GetChild(0).position;

        m_WayPointPositions.Clear();

        // 자식 오브젝트들 가져오기
        for (int i = 1, iLen = transform.childCount; i < iLen; i++)
        {
            var wayPointPosition = transform.GetChild(i).position;
            m_WayPointPositions.Add(wayPointPosition);
        }

        m_IsInit = true;
    }

    public WayPointData GetWayPointData()
    {
        if(!m_IsInit)
        {
            InitPosition();
        }

        return new WayPointData(m_StartPosition, m_WayPointPositions);
    }
}
