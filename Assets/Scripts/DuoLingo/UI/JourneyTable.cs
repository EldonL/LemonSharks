using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyTable : MonoBehaviour
{
    public JourneyTableFrame journeyTableFrame; // Reference to the Model
    public JourneyDisc journeyDisc; // Reference to the View



    public GrabbablePart grabbablePart; 

    void Awake()
    {
        journeyTableFrame.OnRotationChanged += HandleRotationChanged;
    }

    void Start()
    {


    }

    private void OnDestroy()
    {

        journeyTableFrame.OnRotationChanged -= HandleRotationChanged;
    }

    private void HandleRotationChanged(Vector3 rotation)
    {
        // Logic to determine movement based on rotation
        // Vector3 movement = new Vector3(0, 0,rotation.z); // Example mapping
        journeyDisc.UpdatePosition(rotation);
    }



    public void OnSelected()
    {
        grabbablePart.OnSelected();
    }

    public void OnUnSelected()
    {
        grabbablePart.OnUnSelected();
    }

}
