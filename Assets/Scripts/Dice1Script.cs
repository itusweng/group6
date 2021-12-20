using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice1Script : MonoBehaviour{
    private Rigidbody rb;
    public static Vector3 dice1Velocity;

    public Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start(){
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        dice1Velocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space)){
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = spawnPoint;
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
