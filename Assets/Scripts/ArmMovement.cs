using System.Net;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine (Transform[] points)
    {
        lr.positionCount = points.Length; //length is the three points
        this.points = points;

    }

    private void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }

        Debug.Log(points.Length);
    }
}
