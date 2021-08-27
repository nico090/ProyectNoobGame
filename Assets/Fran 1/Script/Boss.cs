using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int fase;
    public GameObject projectile;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public float bulletForce;
    public Transform[] firePoints = new Transform[14];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fase == 1)
        {
            Invoke("DisparoGiro", 1f);

            fase = 0;
        }
    }

    public void DisparoGiro()
    {

        for (int i = 0; i != 14; i++)
        {
            GameObject bullet = Instantiate(projectile, firePoints[i].position, firePoints[i].rotation);

            Rigidbody rg = bullet.GetComponent<Rigidbody>();
            rg.AddForce(firePoints[i].forward * bulletForce, ForceMode.Impulse);
        }
        
        fase = 1;
        
    }

    public void CambioFase()
    {
        fase = 1;
    }
}
