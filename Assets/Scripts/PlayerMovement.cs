using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;

    [SerializeField] private float minSwipeDistance = 100f;

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            startPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame)
        {
            endPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            DetectSwipe();
        }
    }

    private void DetectSwipe()
    {
        Vector2 swipe = endPosition - startPosition;

        if (swipe.magnitude < minSwipeDistance)
            return;

        // Horizontal swipe
        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            if (swipe.x > 0)
                Debug.Log("Swipe Right");
            else
                Debug.Log("Swipe Left");
        }
        // Vertical swipe
        else
        {
            if (swipe.y > 0)
                Debug.Log("Swipe Up");
            else
                Debug.Log("Swipe Down");
        }
    }
}
