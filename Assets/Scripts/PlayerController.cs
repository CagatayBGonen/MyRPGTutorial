using UnityEngine;
using UnityEngine.InputSystem;

//make sure that we always get a PlayerMotor
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    //getting camera
    Camera cam;
    //Creating a reference to PlayerMotor
    PlayerMotor motor;

    
    void Start()
    {
        //initilizing camera
        cam = Camera.main;
        //initiliazing motor
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //checking player input (left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // casting ray from camera to wherever we click
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //information about what we hit with this ray
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,100,movementMask))
            {
                //Move our playey to what we hit
                motor.MoveToPoint(hit.point);
                //Stop focusing any obj
            }
        }
    }



}
