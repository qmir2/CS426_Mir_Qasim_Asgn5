using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showcursor : MonoBehaviour
{

    public GameObject cats;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        cats = GameObject.Find("cat");
        if (!cats)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
