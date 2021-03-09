using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CollectLaptop : NetworkBehaviour
{
    // Start is called before the first frame update
    // public cat cat;
    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided with laptop");
        Destroy(gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
