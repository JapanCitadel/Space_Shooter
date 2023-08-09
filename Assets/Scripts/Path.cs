using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] listPoints;
    public int startAt = 0;
    public int directionMove = 1;

    private void OnDrawGizmos()
    {
        if(listPoints == null)
        {
            return;
        }
        for (int i=1; i<listPoints.Length; i++)
        {
            Gizmos.DrawLine(listPoints[i - 1].position, listPoints[i].position);
        }
    }

    public Transform getPointAt(int p)
    {
        return listPoints[p];
    }

    internal Transform getNextPoint()
    {
        startAt += directionMove;
        return listPoints[startAt];
    }
}
