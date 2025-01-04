using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyTableFrame : MonoBehaviour
{
    public delegate void RotationChangedEvent(Vector3 rotation);
    public event RotationChangedEvent OnRotationChanged;

    private void UpdateRotation(Vector3 newRotation)
    {
       // if (Vector3.Distance(newRotation, previousRotation) > 0.1f)  // Adjust threshold as needed
       // {
            OnRotationChanged?.Invoke(newRotation); // Notify listeners of significant rotation change
            transform.Rotate(0f, 0f, newRotation.z *45f * Time.deltaTime);
        //}
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            UpdateRotation(new Vector3(0,0,-0.5f));
        }
        if(Input.GetKey(KeyCode.D))
        {
            UpdateRotation(new Vector3(0,0,0.5f));
        }
    }
}
