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
    public Transform oneSide, twoSide, threeSide;

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
            isStopped = false;
        }
        
    }

    private void OnTriggerStay(Collider col)
    {
       
        if (col.gameObject.CompareTag("DiceCheckZone") && !isStopped)
        {
            
            if (diceVelocity.magnitude < 0.01f)
            {
                float onePos = Mathf.Round(oneSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                float twoPos = Mathf.Round(twoSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                float threePos = Mathf.Round(threeSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                if (onePos > twoPos && onePos > threePos)
                {
                    diceResult = 1;
                }
                else if (twoPos > onePos && twoPos > threePos)
                {
                    diceResult = 2;
                }
                else if (threePos > onePos && threePos > twoPos)
                {
                    diceResult = 3;
                }
                else if (onePos < twoPos && onePos < threePos)
                {
                    diceResult = 6;
                }
                else if (twoPos < onePos && twoPos < threePos)
                {
                    diceResult = 5;
                }
                else if (threePos < twoPos && threePos < onePos)
                {
                    diceResult = 4;
                }
                isStopped = true;
            }
        }
    }
}