using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojhon : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    private bool Choque;
    private Animator animator;
    void Start()
    {
        /* estas son las llamadas a los componentes, de esta forma accedemos mediante variables a los componentes que estan en el inspector**/
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        /*la linea 24 y 25 son solo para modificar para que lado esta viendo el jugador**/
        if (horizontal<0.0f) transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        else if(horizontal>0.0f)transform.localScale=new Vector3(1.0f, 1.0f, 1.0f);
        animator.SetBool("corriendo",horizontal!=0.0f&& Physics2D.Raycast(transform.position, Vector3.down, 0.1f));//pregunto si horizontal es distinto de 0 entonces esta corriendo
        animator.SetBool("saltando", !Physics2D.Raycast(transform.position, Vector3.down, 0.1f));//pregunto si el raycast no esta tocando el suelo es por que esta saltando
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))//esto es para que jhon no sea un flapybird, osea para que salte solo si esta tocando el suelo
        {
            Choque = true;
        }
        else Choque = false;

        if (Input.GetKeyDown(KeyCode.W)&& Choque)
        {
            Saltar();
        }
    }
    private void Saltar()
    {
        Rigidbody2D.AddForce(Vector2.up*fuerzaSalto);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
