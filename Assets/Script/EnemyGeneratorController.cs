using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float repeatTime = 1.75f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateEnemy(){
        Vector3 desfase = new Vector3(Random.Range(1.00f,5.00f),0,0);

        transform.position += desfase;
        Instantiate(enemyPrefab,transform.position, Quaternion.identity);
        transform.position -= desfase;
    }
}
