using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyTableFrame : MonoBehaviour
{
    public delegate void RotationChangedEvent(Vector3 rotation);
    public event RotationChangedEvent OnRotationChanged;
    private Quaternion lastRotation = new(); // Store the last rotation
    public bool isRotating;          // Flag to indicate if the object is rotating

    void Start()
    {
        // Initialize the last rotation with the current rotation
        lastRotation = transform.rotation;
    }
    private void UpdateRotation(Vector3 newRotation)
    {
       // if (Vector3.Distance(newRotation, previousRotation) > 0.1f)  // Adjust threshold as needed
       // {
            OnRotationChanged?.Invoke(newRotation); // Notify listeners of significant rotation change
            transform.Rotate(0f, 0f, newRotation.z  * Time.deltaTime);
        //}
    }

    public void Update()
    {
        // Calculate the angle difference between the current and last rotation
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
        if(!isRotating)
        {            
            return;
        }
        UpdateRotation(new Vector3(0, 0, lastRotation.z));


    }
}
