using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracerSettings : MonoBehaviour
{
    
    public bool traceOnlyAfterHit = false;
    public Color beforeHitColor = Color.white;
    public Color afterHitColor = Color.white;

    // Update is called once per frame
    void Update()
    {
        PathTracer.traceOnlyAfterHit = traceOnlyAfterHit;
        PathTracer.beforeHitColor = beforeHitColor;
        PathTracer.afterHitColor = afterHitColor;
    }
}
