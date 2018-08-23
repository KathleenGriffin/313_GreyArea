using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoColours : MonoBehaviour
{

    Renderer rend;
    public Shadows shadowScript;

    public GameObject white;
    public GameObject black;
    BoxCollider2D whiteCol;
    BoxCollider2D blackCol;
    BoxCollider2D powerCol;


    // Use this for initialization
    void Start()
    {
        powerCol = GetComponent<BoxCollider2D>();
        whiteCol = white.GetComponent<BoxCollider2D>();
        blackCol = black.GetComponent<BoxCollider2D>();
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
        powerCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 300 * Time.deltaTime);



        //a cheat way to make the powerup appear for the video hehehe
        if (Input.GetKeyDown(KeyCode.P))
        {
            rend.enabled = true;
            powerCol.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            rend.enabled = false;
            powerCol.enabled = false;
        }

        //you can only collect it when it's visible
        if ((blackCol.IsTouching(powerCol) || whiteCol.IsTouching(powerCol)) && rend.enabled == true)
        {
            IsCollected();
        }




    }

    //when someone picks up the poweruppppp!
    void IsCollected()
    {
        shadowScript.discoTime = true;
        rend.enabled = false;
        powerCol.enabled = false;
    }
}
