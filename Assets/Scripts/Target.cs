using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

 
public class Target : NetworkBehaviour
{
    public Score scoreManager;
    // AudioSource shatterSound;

    void Start()
    {
        // shatterSound = GetComponent<AudioSource>();
    }
 
    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision) {
        //on collision adding point to the score
        scoreManager.AddPoint();
        // GetComponent<AudioSource>().Play();
        // printing if collision is detected on the console
        Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
        Destroy(gameObject);

        // if (collision.gameObject.tag == "Laptop"){
        //     shatterSound.Play();
        // }

    }
}