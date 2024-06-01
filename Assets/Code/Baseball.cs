using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class Baseball : MonoBehaviour
{
    [Header("Baseball Parameters")]
    public float radius = 0.5f;
    public float airDensity = 0.1f;
    public float lifespan = 5;
    public bool wasHit = false;

    [Header("Pitch Parameters")]
    public float pitchSpeedMph = 95f;  // strength of the pitch in mph
    public float thetaDegrees = 45f;   // horizontal angle in degrees
    public float phiDegrees = 0f;      // vertical angle in degrees (0 means on the ground plane)

    [Header("Advanced Physics Parameters")]
    public float dragCoefficient = 0.5f;
    public float magnusCoefficient = 0.02f;
    public float horizontalSpin; //in degrees
    public float verticalSpin;   //in degrees
    Vector3 angularVelocitDirectiony;
    float angularVelocityMagnitude;


    [Header("Path Tracer Variables")]
    public GameObject pathTracerPrefab;


    private Rigidbody rb;
    private Vector3 pitchDirection;
    private Vector3 debugLocation;

    GameObject beforeHitPathTracer;
    GameObject afterHitPathTracer;

    PathTracer beforeHitPathTracerScript;
    PathTracer afterHitPathTracerScript;

    private bool afterHitTracerCreated = false;

    void Start()
    {
        debugLocation = new Vector3(6.96f, 2.6f, 4.78f);
        rb = GetComponent<Rigidbody>();

        angularVelocitDirectiony = SphericalToCartesian(1f, verticalSpin, horizontalSpin);
        rb.angularVelocity = angularVelocitDirectiony * angularVelocityMagnitude;
        Debug.Log("real: angular velocity: " + rb.angularVelocity);
        Debug.Log("Calc: angular velocity: " + angularVelocitDirectiony);


        //set up path tracer
        //Create new path tracer and access it's PathTracer script

        GenerateBeforeHitPathTracer();

        PitchBall();
    }
    void Update()
    {
        //path tracer logic
        GenerateAfterHitPathTracer();
        UpdatePathTraces();

        //ball logic
        Despawn();
    }
    void FixedUpdate()
    {
        if(!wasHit)
        {
            ApplyDrag();
            ApplyMagnusEffect();
        }
    }

    void GenerateBeforeHitPathTracer()
    {
        if(PlayerSettings.Instance.TracePitch)
        {
            if (!PathTracer.traceOnlyAfterHit)
            {
                beforeHitPathTracer = Instantiate(pathTracerPrefab, transform.position, Quaternion.identity);
                beforeHitPathTracerScript = beforeHitPathTracer.GetComponent<PathTracer>();
                beforeHitPathTracerScript.InitializedPathTracer(gameObject, false);
            }
        }

    }

    void GenerateAfterHitPathTracer()
    {   
        if(PlayerSettings.Instance.TraceHit)
        {
            if (wasHit && !afterHitTracerCreated)
            {
                Debug.Log("Generating after hit tracer");
                afterHitPathTracer = Instantiate(pathTracerPrefab, transform.position, Quaternion.identity);
                afterHitPathTracerScript = afterHitPathTracer.GetComponent<PathTracer>();
                afterHitPathTracerScript.InitializedPathTracer(gameObject, true);

                afterHitTracerCreated = true;
            }
        }
    }

    void UpdatePathTraces()
    {
        if (!wasHit && beforeHitPathTracerScript != null)
            beforeHitPathTracerScript.AddPosition();
        else if( afterHitPathTracerScript != null)
        {
            if (afterHitPathTracerScript.lineRenderer.positionCount == 0)
                afterHitPathTracerScript.AddPosition(beforeHitPathTracerScript.lineRenderer.GetPosition(beforeHitPathTracerScript.lineRenderer.positionCount - 1));
            else
                afterHitPathTracerScript.AddPosition();
        }
    }

    public void InitializePitchData(PitchData data)
    {
        pitchSpeedMph = data.pitchSpeedMph;
        thetaDegrees = data.thetaDegrees;
        dragCoefficient = data.dragCoefficient;
        phiDegrees = data.phiDegrees;
        //magnusCoefficient = data.magnusCoefficient;
        radius = data.radius;
        airDensity = data.airDensity; 
        horizontalSpin = data.horizontalSpin;
        verticalSpin = data.verticalSpin;
        angularVelocityMagnitude = data.angularVelocityMagnitude;
    }

    void PitchBall()
    {
        pitchDirection = SphericalToCartesian(1f, thetaDegrees, phiDegrees);  // 1f as we want a normalized direction
        float pitchSpeedMetersPerSecond = pitchSpeedMph * 0.44704f;  // converting mph to m/s

        rb.velocity = pitchDirection * pitchSpeedMetersPerSecond;
    }

    Vector3 SphericalToCartesian(float radius, float theta, float phi)
    {
        theta *= Mathf.Deg2Rad;  // convert degrees to radians
        phi *= Mathf.Deg2Rad;

        float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = radius * Mathf.Cos(phi);
        float z = radius * Mathf.Sin(phi) * Mathf.Sin(theta);

        return new Vector3(x, y, z);
    }

    void ApplyDrag()
    {
        Vector3 dragForce = -dragCoefficient * rb.velocity.normalized * rb.velocity.sqrMagnitude;
        rb.AddForce(dragForce);
    }

    void ApplyMagnusEffect()
    {
        var direction = Vector3.Cross(rb.angularVelocity, rb.velocity);
        var magnusForce = 4 / 3f * Mathf.PI * Mathf.Pow(radius, 3) * airDensity /* magnusCoefficient*/;
        rb.AddForce(magnusForce * direction);
    }
     void Despawn()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0 && wasHit == false) 
        {
            Destroy(gameObject);
        }
    }
    void OnDrawGizmos()
    {
        //draws pitch direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(debugLocation, debugLocation + SphericalToCartesian(1f, thetaDegrees, phiDegrees) * 10);  // 5 is just an arbitrary length for visualization purposes

        //draw angular velocity direction
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(debugLocation, transform.position + angularVelocitDirectiony * 5);  // 5 is just an arbitrary length for visualization purposes
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baseball Bat")
        {
            wasHit = true;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Ball hit bat");
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        }
    }
}