using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MilkCollision : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision) {
        //on collision adding point to the score

        // printing if collision is detected on the console
        Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
        Destroy(gameObject);

    }
}
