using UnityEngine;
using UnityEngine.InputSystem;

//make sure that we always get a PlayerMotor
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    //defining a variable that stores current focus
    public Interactable focus;

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
                RemoveFocus();
            }
        }

        //for player interaction
        //checking player input (right mouse button)
        if (Input.GetMouseButtonDown(1))
        {
            // casting ray from camera to wherever we click
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //information about what we hit with this ray
            RaycastHit hit;
            //We check if ray hits something interactable
            if(Physics.Raycast(ray, out hit,100))
            {
                //check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if we did set it as focus
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }
    //function that set the focus
    void SetFocus(Interactable newFocus)
    {
        //Checking if we already focused the interactable
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDeFocused();
            }         
            //initialize focus with newFocus from interactable
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }       
        //calls the method onfocsed and send player transform as a parameters.
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }

}
