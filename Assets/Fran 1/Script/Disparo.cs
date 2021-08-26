using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform cam;
    public GameObject projectile;
    public Transform firePoint;
    public float bulletForce;

    public Transform targer;

    public Camera mainCamara;


    void Start()
    {
      //  mainCamara = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("Shoot", 0.0f);
        }

        
    }

    void Shoot()
    {


        Ray cameraRay = mainCamara.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);


            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);

            Rigidbody rg = bullet.GetComponent<Rigidbody>();
            rg.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }



    }
}
