using UnityEngine;

// Ensure the GameObject this script is attached to has a Camera component
[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCameraViewport();
    }

    // Adjust the camera's viewport to maintain a square aspect ratio
    void AdjustCameraViewport()
    {
        // Calculate the aspect ratio of the screen
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = 1.0f / screenAspect;
        Rect rect = cam.rect;

        rect.width = 1.0f;
        rect.height = 0.9f;
        rect.x = 0;
        rect.y = (1.0f - scaleHeight) / 2.0f;

        cam.rect = rect;

        //if (screenAspect > 1)
        //{
        //    // If the screen is wider than it is tall
        //    float scaleHeight = 1.0f / screenAspect;
        //    Rect rect = cam.rect;

        //    rect.width = 1.0f;
        //    rect.height = scaleHeight;
        //    rect.x = 0;
        //    rect.y = (1.0f - scaleHeight) / 2.0f; // Center the viewport vertically

        //    cam.rect = rect; // Apply the adjusted viewport
        //}
        //else
        //{
        //    // If the screen is taller than it is wide
        //    float scaleWidth = screenAspect;
        //    Rect rect = cam.rect;

        //    rect.width = scaleWidth;
        //    rect.height = 1.0f;
        //    rect.x = (1.0f - scaleWidth) / 2.0f; // Center the viewport horizontally
        //    rect.y = 0;

        //    cam.rect = rect; // Apply the adjusted viewport
        //}
    }

    // Clear the screen before the camera culls the scene
    void OnPreCull()
    {
        GL.Clear(true, true, Color.black); // Clear with a black color
    }
}