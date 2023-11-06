using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBala : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direccion;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direccion * velocidad;
    }
    public void SetDireccion(Vector3 direccion)
    {
        Direccion = direccion;
    }
    public void DestruirBala()
    {
        Destroy(gameObject);
    }
}
