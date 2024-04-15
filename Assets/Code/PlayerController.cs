using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;
    public float mouseSensitivity = 7;
    private float yPlayerRotation;
    private float xPlayerRotation;
    public float leftCameraLimit = 110;
    public float rightCameraLimit = 290;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yPlayerRotation = cameraTransform.rotation.eulerAngles.x;
        xPlayerRotation = cameraTransform.rotation.eulerAngles.y;
        Debug.Log(xPlayerRotation);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }
    void UpdateCamera()
    {
        float XMouseDelta;
        float YMouseDelta;
        XMouseDelta = Input.GetAxis("Mouse X") * mouseSensitivity;
        YMouseDelta = Input.GetAxis("Mouse Y") * mouseSensitivity;
        Debug.Log("Change in Mouse X: " + XMouseDelta);

        yPlayerRotation -= YMouseDelta;
        yPlayerRotation = Mathf.Clamp(yPlayerRotation, -90, 90);
        cameraTransform.localRotation = UnityEngine.Quaternion.Euler(yPlayerRotation, 0f, 0f);

        xPlayerRotation += XMouseDelta;
        xPlayerRotation = Mathf.Clamp(xPlayerRotation, leftCameraLimit, rightCameraLimit);
        transform.localRotation = UnityEngine.Quaternion.Euler(0f, xPlayerRotation, 0f);
    }
}
