using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice2Script : MonoBehaviour{
    static Rigidbody rb;
    public static Vector3 dice2Velocity;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update(){
        dice2Velocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space)){
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = new Vector3(0, 7, -2);
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
