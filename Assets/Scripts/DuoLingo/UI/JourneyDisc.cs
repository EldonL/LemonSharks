using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyDisc : MonoBehaviour
{
    private Vector3 moveSpeed = new Vector3(0,0,0.1f);
    public void UpdatePosition(Vector3 movement)
    {

        moveSpeed.z = Mathf.Abs(moveSpeed.z) * Mathf.Sign(movement.z);
        transform.position += moveSpeed*Time.deltaTime; // Adjust this logic to fit your needs
    }
}
