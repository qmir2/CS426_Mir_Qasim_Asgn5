using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour

{
    public GameObject player;

	// public Transform camTransform;

	// Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
        // transform.rotation = camTransform.rotation * originalRotation;   
    }
}
