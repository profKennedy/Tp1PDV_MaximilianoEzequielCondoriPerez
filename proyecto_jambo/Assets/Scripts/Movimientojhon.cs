using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimientojhon : MonoBehaviour
{
    public GameObject BalaPrefab;
    public float fuerzaSalto;
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    private bool Choque;
    private Animator animator;
    private int Vida = 3;
    public string nombre;
   // private float UltimoDisparo;
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
        if (Input.GetKeyDown(KeyCode.Space) /*Time.time>UltimoDisparo+0.25f*/)
        {
            disparar();
            //UltimoDisparo = Time.time;
        }
        caerse();
    }
    private void Saltar()
    {
        Rigidbody2D.AddForce(Vector2.up*fuerzaSalto);
    }


    private void disparar()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector3.right;
        else direccion = Vector3.left;
        GameObject bala= Instantiate(BalaPrefab, transform.position+direccion*0.1f, Quaternion.identity);
        bala.GetComponent<ScriptBala>().SetDireccion(direccion);// aqui se llama a la funcion de ScripBala para dale la direccion del jugador
    }




    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);//se utiliza solo para el movimiento del jugador sea mas fluido
    }
    public void Golpear()
    {
        Vida = Vida - 1;
        if (Vida == 0)
        {
            Destroy(gameObject);
            ChangeScene(nombre);
        }
    }
    public void ChangeScene(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public void caerse()
    {
        if (transform.position.y<-2.0f)
        {
            Vida = 0;
            ChangeScene(nombre);
        }
    }

}
