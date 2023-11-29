using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCameraMovement : MonoBehaviour
{
    public void OnMouseScrollDelta(InputAction.CallbackContext context)
    {
        Vector2 scrollDelta = context.ReadValue<Vector2>();
        float scrollValue = scrollDelta.y;
        Debug.Log("Mouse Scroll: " + scrollValue);
        // You can use scrollValue to perform actions based on the scroll input.
    }
}
