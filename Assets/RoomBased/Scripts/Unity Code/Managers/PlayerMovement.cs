using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed = 5f;           // Speed for moving
    public float _mouseSensitivity = 300f;  // Mouse sensitivity for rotation
    private float _rotationY = 0f;          // Store the current Y rotation

    private UIManager uiManager;

    Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevent player from rotating due to collisions
    }


    void Update()
    {
        // Check if the middle mouse button is held down for rotation
        if (Input.GetMouseButton(2)) // 2 represents the middle mouse button
        {
            // Hide and lock the cursor while rotating
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Get horizontal mouse movement only for rotation, with adjustable sensitivity
            float _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;

            // Update rotationY for smooth 360-degree rotation
            _rotationY += _mouseX;

            // Apply rotation around the Y-axis only
            Quaternion targetRotation = Quaternion.Euler(0, _rotationY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
        else
        {
            // Show and unlock the cursor when the middle mouse button is released
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        // Get movement input
        float _moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right (A/D)
        float _moveVertical = Input.GetAxis("Vertical");     // Forward/Backward (W/S)

        // Create a movement vector relative to the player's local rotation
        Vector3 movement = transform.right * _moveHorizontal + transform.forward * _moveVertical;

        Vector3 velocity = movement * _moveSpeed;

        rb.velocity = new Vector3(velocity.x, 0, velocity.z);
        
    }
}
