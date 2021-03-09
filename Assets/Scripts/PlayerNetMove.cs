using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetMove : NetworkBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public float speed = 25.0f;
    public float superSpeed = 75.0f;
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 400f;
    public float sensitivityY = 400f;
    public float minimumY = -15f;
    public float maximumY = 60f;
    float rotationY = 0f;
    public float force = 700f;


    public GameObject cannon;
    public GameObject bullet;

    public Camera camera;

    Rigidbody rb;
    Transform t;
    // Start is called before the first frame update

    private void Awake(){
        camera.enabled = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        Cursor.visible = true;
    }

    public override void OnStartLocalPlayer(){
        camera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;


        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += this.transform.right * speed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity -= this.transform.right * speed * Time.deltaTime;
            Cursor.visible = false;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity += this.transform.forward * superSpeed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity -= this.transform.forward * superSpeed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity += this.transform.right * superSpeed * Time.deltaTime;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity -= this.transform.right * superSpeed * Time.deltaTime;
            Cursor.visible = false;
        }


        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
            
        }

        
    }
}
