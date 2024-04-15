using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    GameObject follow;
    Material tracerMaterial;
    public bool afterHitTracer = false;

    [Header("Path Tracer Settings")]
    public static bool traceOnlyAfterHit = false;
    public static Color beforeHitColor = Color.white;
    public static Color afterHitColor = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        //setting up pathtracer depending on the chosen pathtracer settings

        transform.position = follow.transform.position;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, follow.transform.position);
    }

    public void InitializedPathTracer(GameObject follow, bool afterHitTracer)
    {
        //getting necessary variables (this happens before Start)
        tracerMaterial = GetComponent<LineRenderer>().material;
        this.afterHitTracer = afterHitTracer;

        this.follow = follow;

        if (afterHitTracer)
            tracerMaterial.color = afterHitColor;
        else
            tracerMaterial.color = beforeHitColor;
    }

    public void AddPosition()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, follow.transform.position);
    }

    public void AddPosition(Vector3 position)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }
}