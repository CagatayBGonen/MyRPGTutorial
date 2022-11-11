using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //the transform of target to follow
    public Transform targetTransform;
    //Camera's offset from the target
    public Vector3 offset;
    //yaw: yalpalamak. left or right rotation speed based on y axis (y vertical)
    public float yawSpeed = 100f;
    //storing yaw input
    private float currentYaw = 0f;

    //Our current zoom
    private float currentZoom = 10f;
    //our zoom speed
    public float zoomSpeed = 4f;
    //min and max zoom
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f; // for adjusting high of the target

    void Update()
    {
        //getting any changes in scrollwheel and configure with our current zoom. Zooming
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        //this set limits
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        //storing camera rotation
        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

    }

    //LateUpdate to make camera move smooth
    void LateUpdate()
    {
        //setting the position of the camera
        transform.position = targetTransform.position - offset*currentZoom;
        //look at tp target.
        transform.LookAt(targetTransform.position + Vector3.up * pitch); //because target's transform is in its bottom(feet) we need to adjust it.
        //rotating camera based on currentYaw
        transform.RotateAround(targetTransform.position, Vector3.up, currentYaw);
    }
}
