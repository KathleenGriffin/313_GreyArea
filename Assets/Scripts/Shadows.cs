using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {
    Renderer rend;
    bool on = true;
    public bool discoTime = false;
    int discoCount = 0;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        //key bound boogie
        if (Input.GetKeyDown(KeyCode.I)){
            discoTime = true;
        }

        //only do 100 disco flashes
        if (discoTime == true && discoCount < 100) {
            DoDisco();
            //reset disco count so can be used again!
            if (discoCount >= 500) {
                discoCount = 0;
                discoTime = false;
            }
        }

		
	}

    //called by swap powerup
    public void DoSwap() {
        if (on == true) {
            rend.enabled = false;
            on = false;
        }
        else{
            rend.enabled = true;
            on = true;
        }
    }


    //a power up
    public void DoDisco() {
        //Debug.Log("doing disco");


        if ((Time.frameCount % 10) == 0) {
            discoCount++;
            if (on == true) {
                rend.enabled = false;
                on = false;
            }
            else {
                rend.enabled = true;
                on = true;
            }


        }
        
    }

}
