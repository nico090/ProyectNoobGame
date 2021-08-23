using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform targer;

    private Camera mainCamara;


    void Start()
    {

        mainCamara = FindObjectOfType<Camera>();

        /*
        if(targer == null)
        {
            targer = transform;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        Ray cameraRay = mainCamara.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            //transform.LookAt(pointToLook);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }




        /*
        Vector3 mouseWorldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mouseWorldPosition.y = 0;

        Vector3 lookAtDirection = mouseWorldPosition - targer.position;

        targer.up = lookAtDirection;
        */
    }
}
