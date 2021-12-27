﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice1Script : MonoBehaviour{
    private Rigidbody rb;
    public static Vector3 diceVelocity;
    public int diceResult;
    public static bool isStopped;
    public Transform oneSide, twoSide, threeSide;
    public Vector3 spawnPoint;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public void rollDiceMono(){
        float dirX = Random.Range(9100000, 1020000);
        float dirY = Random.Range(8900000, 9700000);
        float dirZ = Random.Range(9400000, 1010000);
        transform.position = spawnPoint;
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 750);
        rb.AddTorque(dirX, dirY, dirZ);
        isStopped = false;
    }
    
    void Update(){
        diceVelocity = rb.velocity;
    }

    public void OnTriggerStay(Collider col){
        if (col.gameObject.CompareTag("DiceCheckZone") && !isStopped){
            if (diceVelocity.magnitude < 0.00001f){
                float onePos = Mathf.Round(oneSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                float twoPos = Mathf.Round(twoSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                float threePos = Mathf.Round(threeSide.TransformPoint(Vector3.zero).y * 10f) * 0.1f;
                if (onePos > twoPos && onePos > threePos) diceResult = 1;
                else if (twoPos > onePos && twoPos > threePos) diceResult = 2;
                else if (threePos > onePos && threePos > twoPos) diceResult = 3;
                else if (onePos < twoPos && onePos < threePos) diceResult = 6;
                else if (twoPos < onePos && twoPos < threePos) diceResult = 5;
                else if (threePos < twoPos && threePos < onePos) diceResult = 4;
                isStopped = true;
                DiceRollButtonScript.diceResultTotal += diceResult;
            }
        }
    }
}