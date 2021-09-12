using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int fase;
    public GameObject projectile;
    public float bulletForce;
    public Transform[] firePoints = new Transform[14];
    public Transform jugador;
    public float speed;
    public Animator animator;

    public bool disparo = true;
    // Start is called before the first frame update
    void Start()
    {
        
        //jugador = FindObjectOfType<Personaje>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fase == 0)
        {
            animator.SetInteger("fase", 1);
            CambioFase();

        }
        
        if (fase >= 1 && fase < 20 && disparo == true)
        {
            disparo = false;
            Invoke("DisparoGiro", 1f);
            Invoke("CambioFase", 1f);
        }



        if (fase >= 20 && fase < 500)
        {
            SeguirJugador();
            //CambioFase();
        }
        if (fase >= 500)
        {
            ResetFase();
        }
    }

    public void DisparoGiro()
    {
        animator.SetInteger("fase", 1);

        if(fase >= 5){
            for (int i = 0; i != firePoints.Length; i++)
            {
                GameObject bullet = Instantiate(projectile, firePoints[i].position, firePoints[i].rotation);

                Rigidbody rg = bullet.GetComponent<Rigidbody>();
                rg.AddForce(firePoints[i].forward * bulletForce, ForceMode.Impulse);
            }   
        }

        disparo = true;
    }

    public void SeguirJugador()
    {
        animator.SetInteger("fase", 0);
        // Transform Tjugador = jugador.GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(jugador.position.x, transform.position.y, jugador.position.z), speed * Time.deltaTime);

        CambioFase();
    }

    public void CambioFase()
    {
        fase = fase + 1;
    }

    public void ResetFase()
    {
        fase = 0;
    }
}
