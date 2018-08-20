using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {
    Renderer rend;
    bool on = true;
    bool discoTime = false;
	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            discoTime = true;
        }

        if (discoTime == true) {
            doDisco();
        }

		
	}

    //a power up
    void doDisco() {
        //Debug.Log("doing disco");
        if ((Time.frameCount % 10) == 0) {
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
