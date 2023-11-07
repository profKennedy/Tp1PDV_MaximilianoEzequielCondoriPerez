using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBala : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direccion;
    public AudioClip sonido;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direccion * velocidad;
    }
    public void SetDireccion(Vector3 direccion)//la funcion es publica por que es llamada en el script de jhon y del enemigo, 
    {                                          // en estos solo se utiliza para que la direccion de la bala corresponda a la direccion en la que vean(jugador o enemigo)
        Direccion = direccion;
    }
    public void DestruirBala()//la funcion destruir bala la usamos en en los eventos de las animaciones y cuando chocan con el enemigo u jhon
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScriptBoss Boss= collision.GetComponent<ScriptBoss>();
        Movimientojhon jhon = collision.GetComponent<Movimientojhon>();//obtenemos los scripts de jhon como del Enemigo
        MovimientoEnemigo Enemigo = collision.GetComponent<MovimientoEnemigo>();
        /*preguntamos si jhon o el enemigo existen y si lo hacen llaman a la funcion Golpear hasta que se les agote la vida*/
        if (jhon != null) jhon.Golpear();
        if (Enemigo != null) Enemigo.Golpear();
        if (Boss != null) Boss.Golpear();
        DestruirBala();
    }
}
