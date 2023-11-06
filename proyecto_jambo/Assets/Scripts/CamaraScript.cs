using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject Jhon;
    void Update()
    {
        Vector3 posicion = transform.position;
        posicion.x = Jhon.transform.position.x;
        //posicion.y = Jhon.transform.position.y;
        transform.position = posicion;
        
    }
}
