using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float zBound = 3.5f, xBound = 7;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayerPosition();

    }

    // Moves the player based on arrow keys input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent the player from leaving the screen
    void ConstrainPlayerPosition()
    {
        // Buttom of the screen
        if (transform.position.z < -zBound)
        { transform.position = new Vector3(transform.position.x, transform.position.y, -zBound); }

        // Top of the screen
        if (transform.position.z > zBound)
        { transform.position = new Vector3(transform.position.x, transform.position.y, zBound); }

        // Left of the screen
        if (transform.position.x < -xBound)
        { transform.position = new Vector3(-xBound, transform.position.y, transform.position.z); }

        // Right of the screen
        if (transform.position.x > xBound)
        { transform.position = new Vector3(xBound, transform.position.y, transform.position.z); }
    }

}
