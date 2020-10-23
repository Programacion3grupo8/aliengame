using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float VelocidadBala;
    public float Limite;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * VelocidadBala);

        if(transform.position.x >= Limite)
        {
            gameObject.SetActive(false);
        }
    }
}
