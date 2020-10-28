using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public GameObject BalaPrefabs;
    private bool move = true;
    public bool btnDone = true;
    private bool btnUp = false;
    private bool btnDown = false;
    private bool btnPausa = false;
    public float Velocidad;
    private float h;
    private float v;
    public int Helio;
    private int cantidadHelioDisminuye = 5;
    public int DañoBala;
    public int CantidadBalas;
    public Transform Cañon;
    private Animator animator;
    public GameObject canvas;

    Rigidbody2D rb2D;
    public Vector2 movimineto;
    bool Estado;
    GameObject[] Balas;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Balas = new GameObject[CantidadBalas];
        animator = GetComponent<Animator>();
        for (int i = 0; i < Balas.Length; i++)
        {
           Balas[i] = (GameObject) Instantiate(BalaPrefabs);
            Balas[i].SetActive(false);
        }

    }

    public void ResetHelium(){
        move = true;
        Helio = 10;
    }

    public void SetHeliumText(){
        canvas.SendMessage("SetScore", Helio);
    }
    void Start(){
        BtnDone();
    }   

    public void MoveUp(){
        btnUp = true;
        btnDone = false;
    }
    public void MoveDown(){
        btnDown = true;
        btnDone = false;
    }
    public void Pausa(){
        btnPausa = true;
        btnDone = false;
    }
    
    public void StartDroppingHelium(){
        InvokeRepeating("DropHelium", 10, 10);
    }
    public void StopDroppingHelium(){
        move = false;
        CancelInvoke("DropHelium");
    }
    private void Update()
    {
        Move();
        SetHeliumText();
        bool shoot = (btnDone && Input.GetButtonDown("Fire1")) || Input.GetKeyDown("space") || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Ended);
        if (!btnPausa && shoot)
        {
            Disparar();
        }

        if(Helio <= 0 && move){
            UpdateState("GameOver");
        }
        else if(Helio >= 500){
            canvas.SendMessage("Win");
        }
        
    }

    private void Move(){
        h = Input.GetAxis("Horizontal");
        if(btnUp){
            v = Time.timeScale / 5;
        }
        else if(btnDown){
           v = -Time.timeScale / 5;
        }
        else{
            v = Input.GetAxis("Vertical");
            //Add touch support
        }
        if(v != 0){
            movimineto = new Vector2(h,v);
        }
      
    }
    public void StopMoving(){
        if(v == 0){
            movimineto = new Vector2(0,-0.05f);  
        }
    }
    public void BtnDone(){
        btnDone = true;
        btnUp = false;
        btnDown = false;
        btnPausa = false;
    }
    private void FixedUpdate()
    {
        if(move){
            transform.Translate(movimineto * Velocidad);
            LimitarMovimiento();
            StopMoving();
        }


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
            UpdateState("GameOver");
        }
    
    }
    void Disparar()
    {
        if(move){
            for (int i = 0; i < CantidadBalas; i++)
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
    void IncreaseHelium(int cantidad){
        Helio += cantidad;
        Debug.Log("La cantidad de helio actual es de: " + Helio);
    }
    private void DropHelium(){
        Helio -= cantidadHelioDisminuye;
        Helio = Helio < 0 ? 0 : Helio;
        Debug.Log("La cantidad de helio actual es de: " + Helio);
    }

    public void UpdateState(string state = null){
        if(state != null){
            animator.Play(state);
            if(state == "GameOver"){
                move = false;
            }
        }
    }
    public void GameOver(){
        
        canvas.SendMessage("GameOver");
        transform.position = new Vector2(5,-1.3f);
        UpdateState("Ship");
    
    }
}