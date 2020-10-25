using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocity;
    private string[] colors = {"red","blue","yellow","orange","green","purple"};
    public Rigidbody2D rb2d;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
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
        int index = Random.Range(0, 5);
        if(colors[index] == "blue"){
            rb2d.velocity *= 2;
        }
        animator.Play(colors[index] + "balloon");
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Destroyer"){
            Destroy(gameObject);
        }
    }
}
