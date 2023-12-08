using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float force;
    public float grav;
    public bool grounded = true;
    public bool gameO = false;
    private Animator Anim;
    public ParticleSystem splode;
    public ParticleSystem dort;
    public ParticleSystem blud;
    public AudioClip jump;
    public AudioClip die;
    private AudioSource beandip;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= grav;
        Anim = GetComponent<Animator>();
        beandip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded && !gameO)
        {
            playerRB.AddForce(Vector3.up * force,ForceMode.Impulse);
            grounded = false;
            Anim.SetTrigger("Jump_trig");
            dort.Stop();
            beandip.PlayOneShot(jump, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameO)
        {
            grounded = true;
            dort.Play();
        }
        else if (collision.gameObject.CompareTag("Badj"))
        {
            gameO = true;
            Debug.Log("Nice Work Dumbass! You FUCKING DIED!");
            Anim.SetBool("Death_b", true);
            Anim.SetInteger("DeathType_int", 1);
            splode.Play();
            blud.Play();
            dort.Stop();
            beandip.PlayOneShot(die, 1.0f);
        }
    }
}
