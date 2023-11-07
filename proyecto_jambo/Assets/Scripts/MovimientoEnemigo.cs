using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public GameObject BalaEnemiga;
    public GameObject Jhon;
    private float UltimaDisparo;
    private int Vida=1;
    void Update()
    {
        if (Jhon == null) return;
        Vector3 direccion = Jhon.transform.position - transform.position;//obtenemos la distancia que hay entre el enemigo y jhon
        if (direccion.x <= 0.0f) transform.localScale=new Vector3(-1.0f,1.0f,1.0f);//usamos la distancia para evaluar a que direccion va a mirar el enemigo
        else transform.localScale=new Vector3(1.0f, 1.0f, 1.0f);                   //izquierda o derecha

        float distancia = Mathf.Abs(Jhon.transform.position.x - transform.position.x);//hace que la distancia siempre sea positiva
        if (distancia <= 1.5f && Time.time > UltimaDisparo + 1.0f)// se determina el espacio en el que el enemigo dispara y el enfiramiento del disparo
        {
            Disparar();
            UltimaDisparo = Time.time;
        }
    }
    private void Disparar()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector3.right;
        else direccion = Vector3.left;
        GameObject bala = Instantiate(BalaEnemiga, transform.position + direccion * 0.1f, Quaternion.identity);
        bala.GetComponent<ScriptBala>().SetDireccion(direccion);//se llama a la funcion Setdireccion de ScriptBala para que la bala vaya en direccion a donde ve el enemigo
    }
    public void Golpear()
    {
        Vida = Vida - 1;
        if (Vida == 0) Destroy(gameObject);
    }
}
