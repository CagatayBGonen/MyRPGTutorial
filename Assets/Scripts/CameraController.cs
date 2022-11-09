using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //the transform of target to follow
    public Transform targetTransform;
    //Camera's offset from the target
    public Vector3 offset;
    //Our current zoom
    private float currentZoom = 10f;
    public float pitch = 2f; // for adjusting high of the target


    //LateUpdate to make camera move smooth
    void LateUpdate()
    {
        Debug.Log("LateUpdate");
        //setting the position of the camera
        transform.position = targetTransform.position - offset*currentZoom;
        //look at function.
        transform.LookAt(targetTransform.position + Vector3.up * pitch); //because target's transform is in its bottom(feet) we need to adjust it.
    }
}
