using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState{Inicio, Pausa, Jugando, GameOver};
    public GameState estado = GameState.Inicio;
    public GameObject home;
    public GameObject pausa;
    public Text helio;
    public Text maxHelio;
    public GameObject gameOver;
    public GameObject player;
    public GameObject enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        SetScore(10);
    }


    // Update is called once per frame
    void Update()
    {

        if(estado == GameState.Jugando && Input.GetKeyDown("escape")){
           Pausa();
        }
        else if(estado == GameState.Pausa && Input.GetKeyDown("escape")){
           Jugando();
        }
    }

    public void Pausa(){
        estado = GameState.Pausa;
        //player.enabled = false;
        Time.timeScale = 0;
        pausa.SetActive(true);
    }

    public void Jugando(){
        Time.timeScale = 1f;
        EmpezarJuego();
    }

    public void EmpezarJuego(){
        estado = GameState.Jugando;
        enemyGenerator.SetActive(true);
        player.SetActive(true);
        player.SendMessage("ResetHelium");
        player.transform.position = new Vector2(5,0);
        home.SetActive(false);
        pausa.SetActive(false);
        gameOver.SetActive(false);
        enemyGenerator.SendMessage("StartCreatingEnemies");
        player.SendMessage("StartDroppingHelium");
    }
    public void Inicio(){
        if(estado != GameState.Inicio){
            estado = GameState.Inicio;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Principal");
        }
   
    }

    public void GameOver(){
        if(estado != GameState.GameOver){
            estado = GameState.GameOver;
            enemyGenerator.SendMessage("StopCreatingEnemies");
            player.SendMessage("StopDroppingHelium");
            enemyGenerator.SetActive(false);
            home.SetActive(false);
            pausa.SetActive(false);
            gameOver.SetActive(true);
        }
        

    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit");

    }
    public void SetScore(int score = 0){
        // puntuacion
        helio.text = "Helio: " + score.ToString();
        SetMaxScore(score);
        maxHelio.text = "Max Score: " + GetMaxScore().ToString();
    }

    public int GetMaxScore(){
        return PlayerPrefs.GetInt("MaxHelium",0);
    }

    public void SetMaxScore(int score){
        if(score > GetMaxScore()){
            PlayerPrefs.SetInt("MaxHelium",score);
        }
    }
}

    