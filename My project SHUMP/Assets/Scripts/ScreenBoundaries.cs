using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public BoxCollider2D boundaryTop;
    public BoxCollider2D boundaryBottom;
    public BoxCollider2D boundaryLeft;
    public BoxCollider2D boundaryRight;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustBoundaries();
    }

    void AdjustBoundaries()
    {
        // Get the camera bounds
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Adjust the size and position of the top boundary
        boundaryTop.size = new Vector2(camWidth * 2, 1); // Adjust the height (1) as needed
        boundaryTop.offset = new Vector2(0, camHeight + boundaryTop.size.y / 2);

        // Adjust the size and position of the bottom boundary
        boundaryBottom.size = new Vector2(camWidth * 2, 1); // Adjust the height (1) as needed
        boundaryBottom.offset = new Vector2(0, -camHeight - boundaryBottom.size.y / 2);

        // Adjust the size and position of the left boundary
        boundaryLeft.size = new Vector2(1, camHeight * 2); // Adjust the width (1) as needed
        boundaryLeft.offset = new Vector2(-camWidth - boundaryLeft.size.x / 2, 0);

        // Adjust the size and position of the right boundary
        boundaryRight.size = new Vector2(1, camHeight * 2); // Adjust the width (1) as needed
        boundaryRight.offset = new Vector2(camWidth + boundaryRight.size.x / 2, 0);
    }
}