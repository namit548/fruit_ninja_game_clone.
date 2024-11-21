//using System.Collections;
//using System.Collections.Generic;
////using System.Numerics;
//using UnityEngine;
////using UnityEngine.UIElements.Experimental;

//public class Blade : MonoBehaviour
//{
//    public float minVelo = 0.1f;

//    private Rigidbody2D rb;
//    private Vector3 lastMousePos;
//    private Vector3 mouseVelo;
//    private Collider2D col;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        col = GetComponent<Collider2D>();
//        // Col = GetComponet<Collider2D>();
//    }
//    private void Update()
//    {
//        col.enabled = IsMouseMoving();

//        SetBladeToMouse();
//    }
//    private void SetBladeToMouse()
//    {
//        var mousePos = Input.mousePosition;
//        mousePos.z = 10;
//        rb.position = Camera.main.ScreenToWorldPoint(mousePos); //        rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
//                                                                //Camera.main.ScreenToWorldPoint() converts this screen space position into world space.
//                                                                //rb.position -making the blade follow the mouse in the game.
//    }
//    private bool IsMouseMoving()
//    {
//        Vector3 curMousePos = transform.position;
//        float traveled = (lastMousePos - curMousePos).magnitude;
//        lastMousePos = curMousePos;
//        if (traveled > minVelo)
//        {
//            return true;
//        }
//        else return false;





//    }
//}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;  // Minimum velocity to consider the mouse as "moving"

    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // Initialize lastMousePos to the initial mouse position in world space
        lastMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void Update()
    {
        // Enable collider only if the mouse is moving
        col.enabled = IsMouseMoving();

        // Move the blade to follow the mouse position
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        // Get the mouse position in screen space and convert to world space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;  // Set Z distance from the camera
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Update the blade position to follow the mouse
        rb.position = worldPos;
    }

    private bool IsMouseMoving()
    {
        // Get the current mouse position in world space
        Vector3 curMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        // Calculate the distance moved by the mouse since the last frame
        float traveled = (curMousePos - lastMousePos).magnitude;

        // Update lastMousePos to the current mouse position
        lastMousePos = curMousePos;

        // Return true if the mouse moved more than the minimum velocity, false otherwise
        return traveled > minVelo;
    }
}


















