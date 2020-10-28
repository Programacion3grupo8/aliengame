using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float repeatTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCreatingEnemies(){
        InvokeRepeating("CreateEnemy", 0f, repeatTime);
    }
    public void StopCreatingEnemies(){
        CancelInvoke("CreateEnemy");
    }
    private void CreateEnemy(){
        Vector3 desfase = new Vector3(Random.Range(0f,5.00f),0,0);

        transform.position += desfase;
        Instantiate(enemyPrefab,transform.position, Quaternion.identity);
        transform.position -= desfase;
    }

    public void CreateCount(int cantidad){
        for(int x = 0; x < cantidad; x++){
            CreateEnemy();
        }
    }
}
