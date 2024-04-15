using UnityEngine;
public class ControllerAdjustment : MonoBehaviour 
{ 
    public Transform leftController; 
    public Transform rightController;

    public float armLengthMultiplierX = 1f;
    public float armLengthMultiplierY = 1f;
    public float armLengthMultiplierZ = 1f; 

    void Update() { 
        // Example: Move controllers forward to simulate longer arms
        leftController.localPosition = new Vector3(leftController.localPosition.x * armLengthMultiplierX, leftController.localPosition.y * armLengthMultiplierY, leftController.localPosition.z * armLengthMultiplierZ); 
        rightController.localPosition = new Vector3(rightController.localPosition.x * armLengthMultiplierX, rightController.localPosition.y * armLengthMultiplierY, rightController.localPosition.z * armLengthMultiplierZ); 
    } 
}