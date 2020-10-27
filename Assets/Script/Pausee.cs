using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pausee : MonoBehaviour
{
    bool active;
    Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }

    }


    public void Salir()
    {
        Application.Quit();
        Debug.Log("Exit");


    }
}

