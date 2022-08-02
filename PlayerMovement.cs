using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float xBounds = 1.125f;
    public float zBounds = 1.125f;
    public float travelDistance = 0.25f;

    void Update()
    {
        // Move player a fixed distance when WASD keys are pressed
        transform.position += new Vector3(travelDistance * 
        (((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < xBounds) ? 1 : 
        (((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && transform.position.x > -xBounds) ? -1 : 0)), 0, travelDistance * 
        (((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.z < zBounds) ? 1 : 
        (((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.z > -zBounds) ? -1 : 0)));
    }
}
