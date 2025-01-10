using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyDisc : MonoBehaviour
{
    private Vector3 moveSpeed = new Vector3(0, 0, 0.1f);
    public MeshRenderer meshRenderer;
    private Vector2 offset = Vector2.zero;

    public void UpdatePosition(Vector3 movement)
    {

        moveSpeed.z = Mathf.Abs(moveSpeed.z) * Mathf.Sign(movement.z);
        transform.position += moveSpeed * Time.deltaTime; // Adjust this logic to fit your needs
        offset.x+= moveSpeed.z *Time.deltaTime *5;
        meshRenderer.material.mainTextureOffset = offset; // Adjust the axis if needed
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            UpdatePosition(new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            UpdatePosition(new Vector3(0, 0, -1));
        }

    }
}
