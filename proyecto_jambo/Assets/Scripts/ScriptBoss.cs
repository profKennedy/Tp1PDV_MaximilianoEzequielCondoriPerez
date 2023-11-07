using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBoss : MonoBehaviour
{
    [SerializeField] private float Velocidad;
    [SerializeField] private float amplitud;
    public GameObject BalasPrefaboss;
    public GameObject Jhon;
    private Rigidbody2D rb;
    private float Ultimoseg;
    private float Ultimodisparo;
    private int Vida = 15;
    public string nombre;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ultimoseg = Time.time;
    }
    private void Update()
    {
        if (Jhon == null) return;
        Vector3 direccion = Jhon.transform.position - transform.position;//obtenemos la distancia que hay entre el enemigo y jhon
        if (direccion.x <= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);//usamos la distancia para evaluar a que direccion va a mirar el enemigo
        else transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);                   //izquierda o derecha

        float distancia = Mathf.Abs(Jhon.transform.position.x - transform.position.x);//hace que la distancia siempre sea positiva
        if (distancia <= 1.5f && Time.time > Ultimodisparo + 1.5f)// se determina el espacio en el que el enemigo dispara y el enfiramiento del disparo
        {
            Disparar();
            Ultimodisparo = Time.time;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float valorSeno = Mathf.Sin((Time.time - Ultimoseg) * Velocidad * Mathf.PI * 2) * amplitud;
        rb.velocity= new Vector2(0, valorSeno);

    }



    private void Disparar()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector3.right;
        else direccion = Vector3.left;
        GameObject bala = Instantiate(BalasPrefaboss, transform.position + direccion * 0.4f, Quaternion.identity);
        bala.GetComponent<ScriptBala>().SetDireccion(direccion);
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


}
