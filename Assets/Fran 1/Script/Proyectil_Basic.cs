using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Basic : MonoBehaviour
{
    public float speed;
    public float damage;
    void Start()
    {
        //speed = 2f;
        //damage = 3f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Boss>() != null)
        {
            Destroy(this.gameObject);
        }
    }
    
}
