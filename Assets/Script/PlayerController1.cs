using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start(){
        InvokeRepeating("DropHelium", 10, 10);
    }

    private void DropHelium(){
        Helio -= 5;
        Debug.Log("La cantidad de helio actual es de: " + Helio);
    }
    private void Update()
    {
        movimineto = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            Disparar();
        }

        if(Helio == 0){
            Debug.Log("Game Over");
            GameOver();
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
        limitacion.x = Mathf.Clamp(limitacion.x, 5, 5);
        limitacion.y = Mathf.Clamp(limitacion.y, -4.3f, 4.3f);

        transform.position = limitacion;

        if (Mathf.Abs(limitacion.y) == 4.3f)
        {
            Debug.Log("Game Over");
            GameOver();
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

    void GameOver(){
        SceneManager.UnloadSceneAsync("Principal");
        // UnloadSceneAsync
    }

}
