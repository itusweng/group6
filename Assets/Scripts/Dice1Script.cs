using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice1Script : MonoBehaviour
{
    private Rigidbody rb;
    public static Vector3 diceVelocity;
    public int diceResult;
    private bool isStopped;

    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = spawnPoint;
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }

    private void OnTriggerStay(Collider col)
    {
       
        if (col.gameObject.CompareTag("DiceCheckZone"))
        {
            if (diceVelocity.magnitude == 0)
            {
                isStopped = true;
                if (col.gameObject.name == "Dice1Side1")
                {
                    diceResult = 6;
                }
                else if (col.gameObject.name == "Dice1Side2")
                {
                    diceResult = 5;
                }
                else if (col.gameObject.name == "Dice1Side3")
                {
                    diceResult = 4;
                }
                else if (col.gameObject.name == "Dice1Side4")
                {
                    diceResult = 3;
                }
                else if (col.gameObject.name == "Dice1Side5")
                {
                    diceResult = 2;
                }
                else if (col.gameObject.name == "Dice1Side6")
                {
                    diceResult = 1;
                }
                Debug.Log(diceResult);
            }
        }
    }
}