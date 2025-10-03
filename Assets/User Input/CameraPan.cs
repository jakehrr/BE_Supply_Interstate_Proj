using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed = 6f;
    private Camera _camera;

    private Vector3 lastMousePosition;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        // Only pan while holding right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Convert mouse delta into pan direction
            Vector2 panInput = new Vector2(-mouseDelta.x, -mouseDelta.y);
            // (negative so dragging left moves camera left in screen-space)

            // Rotate input vector by camera yaw
            Vector3 move = Quaternion.Euler(0f, _camera.transform.eulerAngles.y, 0f) *
                           new Vector3(panInput.x, 0f, panInput.y);

            // Apply movement
            transform.position += move * panSpeed * Time.deltaTime;
        }
    }
}
