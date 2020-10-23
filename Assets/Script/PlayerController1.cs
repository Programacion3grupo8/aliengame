using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameObject BalaPrefabs;
    public float Velocidad;
    public int Helio;
    public int DañoBala;
    public int CantidadBalas;
    public Transform Cañon;

    Rigidbody2D rb2D;
    Vector2 movimineto;
    bool Estado;
    GameObject[] Balas;





    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Balas = new GameObject[CantidadBalas];

        for (int i = 0; i < Balas.Length; i++)
        {
           Balas[i] = (GameObject) Instantiate(BalaPrefabs);
            Balas[i].SetActive(false);
        }

    }


    private void Update()
    {
        movimineto = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }





    private void FixedUpdate()
    {
        transform.Translate(movimineto * Velocidad);

        LimitarMovimiento();
    }





    void LimitarMovimiento()
    {
        Vector2 limitacion = transform.position;
        limitacion.x = Mathf.Clamp(limitacion.x, 9, 9);
        limitacion.y = Mathf.Clamp(limitacion.y, -7, 7);

        transform.position = limitacion;

        if (limitacion.y == -7)
        {

        }
        if (limitacion.y == 7)
        {

        }
        else
        {

        }
    }

    void Disparar()
    {
        for (int i = 0; i < Balas.Length; i++)
        {
            if (!Balas[i].activeInHierarchy)
            {
                Balas[i].SetActive(true);
                Balas[i].transform.position = Cañon.position;
                break;
            }
        }
    }

}
