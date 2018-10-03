using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
    private List<Vector2> points;
    bool drawing;

    public void StartDrawing(Vector2 newPoint) {
        drawing = true;
        points = new List<Vector2>();
        lineRenderer.SetPositions(new Vector3[0]);
        SetPoint(newPoint);
        lineRenderer.enabled = true;
    }

    public void UpdateLine(Vector2 newPoint)
    {
        if (drawing && Vector2.Distance(points.Last(), newPoint) > .1f)
        {
            SetPoint(newPoint);
        }
    }

    public void EndDrawing()
    {
        drawing = false;
    }

    public List<Vector2> GetPoints(){
        return points;
    }

    public void Clear(){
        drawing = false;
        points = new List<Vector2>();
        lineRenderer.enabled = false;
    }

    void SetPoint(Vector2 point) {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

}
