using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShpawnBoolder : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject obstickhole;
    private Vector3 pos = new Vector3(25,2,0);

    public float delay;
    public float r8;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", delay, r8);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void spawn()
    {
        if(playerControllerScript.gameO == false)
        {
            Instantiate(obstickhole,pos,obstickhole.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
