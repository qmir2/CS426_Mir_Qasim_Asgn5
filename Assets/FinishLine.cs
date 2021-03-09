using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FinishLine : NetworkBehaviour
{

    public Score scoreManager;
    
	//this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision) {

        if (scoreManager.checkPoint()){
            Destroy(gameObject);
        }
        // printing if collision is detected on the console
        Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


