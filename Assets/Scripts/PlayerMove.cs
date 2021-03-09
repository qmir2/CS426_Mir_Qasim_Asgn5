using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{

    public Camera camera;
    public GameObject bullet;
    
    public AudioSource[] sounds;
    public AudioSource bulletSound;
    public AudioSource catSound;


    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;

    Rigidbody rb;
    Transform t;

    public GameObject cannon;

    private void Awake(){
        camera.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // bulletSound = GetComponent<AudioSource>();

        sounds = GetComponents<AudioSource>();
        bulletSound = sounds[0];
        catSound = sounds[1];

        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    public override void OnStartLocalPlayer()
    {
        camera.enabled = true;
    }

    
    void Update()
    {
        if (!isLocalPlayer)
            return;

        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);

        if (Input.GetMouseButtonDown(0))
        {
            bulletSound.Play();
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
            
        }

    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.tag == "Milk"){
            catSound.Play ();
        }

    }
}