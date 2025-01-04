using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyDisc : MonoBehaviour
{
    Vector3 movement = new Vector3();
    public void UpdatePosition(Vector3 movement)
    {
        this.movement = movement;
        this.movement.x = 0;
        this.movement.y = 0;
        transform.position += this.movement*Time.deltaTime; // Adjust this logic to fit your needs
    }
}
