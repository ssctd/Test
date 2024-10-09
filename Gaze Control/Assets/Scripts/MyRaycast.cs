using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycast : MonoBehaviour
{
    public float mouseSensitivity = 100.0f; // Sensitivity for mouse movement

    float xRotation = 0f; // To track vertical (up/down) rotation
    float yRotation = 0f; // To track horizontal (left/right) rotation

    void Start()
    {
        // Lock the cursor to the center of the screen for a better debugging experience
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input for rotating the camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust vertical rotation (tilting the camera up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp to avoid over-rotation (look too far up/down)

        // Adjust horizontal rotation (turning the camera left and right)
        yRotation += mouseX;

        // Apply both vertical and horizontal rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Raycasting logic
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        // Debug ray to visualize direction
        Debug.DrawRay(transform.position, transform.forward * 100.0f, Color.red);

        // Process raycast hits
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            GameObject hitObject = hit.collider.gameObject;

            // Interact with hit object if needed (this part is optional based on your requirements)
            if (hitObject.transform.parent != null && hitObject.transform.parent.tag == "Floor")
            {
                // Interaction logic (e.g., hit point handling) can go here if needed
            }
        }
    }
}
