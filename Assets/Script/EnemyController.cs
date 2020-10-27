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
    private Animator animator;
    public PlayerController1 player;
    public PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        player = (PlayerController1) FindObjectOfType(typeof(PlayerController1));

        velocity = Random.Range(1.5f, 3.5f);
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.up * velocity;
        collider2D = GetComponent<PolygonCollider2D>();
        GetRandomBalloon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateState(string state = null){
        if(state != null){
            animator.Play(state);
        }
    }

    private void BalloonExplosion(){
        Destroy(gameObject);
    }

    private void GetRandomBalloon(){
        indexColor = Random.Range(0, 5);
        if(colors[indexColor] == "blue"){
            rb2d.velocity *= 2;
        }
        UpdateState(colors[indexColor] + "balloon");
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Destroyer"){
            BalloonExplosion();
        }
        else if(other.gameObject.tag == "Bullet"){
            rb2d.velocity = Vector2.up * 0;
            UpdateState("BalloonDie");
            player.SendMessage("IncreaseHelium",(colors[indexColor] == "blue"?blueBalloonPoints:normalPoints));
            Destroy(collider2D);
        }
    }

}
