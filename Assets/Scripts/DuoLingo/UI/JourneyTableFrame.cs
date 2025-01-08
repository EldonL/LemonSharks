using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class JourneyTableFrame : MonoBehaviour
{
    public delegate void RotationChangedEvent(Vector3 rotation);
    public event RotationChangedEvent OnRotationChanged;
    private Quaternion lastRotation = new(); 
    private bool isRotating;     

    public Transform flag; 
    public Transform hinge;
    private Vector3 lastFlagPosition;
    private Vector3 lastEulerRotation;
    void Start()
    {
        // Initialize the last rotation with the current rotation
        lastRotation = transform.rotation;
        lastFlagPosition = flag.position;
        lastEulerRotation = transform.rotation.eulerAngles;
    }
    private void UpdateRotation(Vector3 newRotation)
    {
       // if (Vector3.Distance(newRotation, previousRotation) > 0.1f)  // Adjust threshold as needed
       // {
            OnRotationChanged?.Invoke(newRotation); // Notify listeners of significant rotation change
            transform.Rotate(newRotation  * Time.deltaTime);
        //}
    }
    public HandGrabInteractor test;
    public void Update()
    {
        // if(Input.GetKey(KeyCode.A)) //testing to code to rotate journey table using keypress for quick debugging
        // {
        //     transform.Rotate(new Vector3(0,0,-1));
        // }
        // if(Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate(new Vector3(0,0,1));
        // }
        // Dalculate the angle difference between the current and last rotation
        float angleDifference = Quaternion.Angle(transform.rotation, lastRotation);

        // Set a threshold to consider as "rotation is happening"
        if (angleDifference > 0.1f)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }

        

        lastRotation = transform.rotation;
        lastFlagPosition = flag.transform.position;
        if(!isRotating)
        {            
            return;
        }

        UpdateRotation(new Vector3(0, 0, transform.rotation.eulerAngles.y -lastEulerRotation.y));
        
        lastEulerRotation = transform.rotation.eulerAngles;

    }
}
