using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocity;
    private string[] colors = {"red","blue","yellow","orange","green","purple"};
    int normalPoints = 1;
    int blueBalloonPoints = 10;
    int indexColor;
    public Rigidbody2D rb2d;
    public Animator animator;
    public PlayerController1 player;

    // Start is called before the first frame update
    void Start()
    {
        player = (PlayerController1) FindObjectOfType(typeof(PlayerController1));

        velocity = Random.Range(1.5f, 3.5f);
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.up * velocity;
        GetRandomBalloon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetRandomBalloon(){
        indexColor = Random.Range(0, 5);
        if(colors[indexColor] == "blue"){
            rb2d.velocity *= 2.5f;
        }
        animator.Play(colors[indexColor] + "balloon");
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Destroyer"){
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Bullet"){
            Destroy(gameObject);

            player.SendMessage("IncreaseHelium",(colors[indexColor] == "blue"?blueBalloonPoints:normalPoints));

        }
    }

}
