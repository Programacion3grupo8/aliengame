using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState{Inicio, Pausa, Jugando, GameOver};
    public GameState estado = GameState.Inicio;
    public GameObject home;
    public GameObject pausa;
    public GameObject player;
    public GameObject enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == GameState.Jugando){
            home.SetActive(false);
            pausa.SetActive(false);
        }

        // if(estado == GameState.Jugando && Input.GetKeyDown("esc")){
        //     estado = GameState.Pausa;
        //     Time.timeScale = 0;
        // }
        // else if(estado == GameState.Pausa && Input.GetKeyDown("esc")){
        //     estado = GameState.Jugando;
        //     Time.timeScale = 1;
        // }
    }

    public void EmpezarJuego(){
        estado = GameState.Jugando;
        enemyGenerator.SetActive(true);
        player.SetActive(true);
    }
}
