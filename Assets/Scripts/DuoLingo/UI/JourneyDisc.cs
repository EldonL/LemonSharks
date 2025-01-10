using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyDisc : MonoBehaviour
{
    private Vector3 moveSpeed = new Vector3(0, 1.0f, 0);
    public MeshRenderer meshRenderer;
    private Vector2 offset = Vector2.zero;

    public void UpdatePosition(Vector3 movement)
    {

        moveSpeed.y = Mathf.Abs(moveSpeed.y) * Mathf.Sign(movement.z);
        transform.localPosition += moveSpeed * Time.deltaTime; // Adjust this logic to fit your needs
        offset.x-= moveSpeed.y *Time.deltaTime;
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
