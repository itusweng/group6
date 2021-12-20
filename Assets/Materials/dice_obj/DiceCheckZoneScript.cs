using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour{
    Vector3 dice1Velocity;
    Vector3 dice2Velocity;

    void FixedUpdate(){
        dice1Velocity = Dice1Script.dice1Velocity;
        dice2Velocity = Dice2Script.dice2Velocity;
    }

    void OnTriggerStay(Collider col){
        if(dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f){
            switch(col.gameObject.name){
                case "Dice1Side1":
                    print("Dice 1: 6");
                    break;
                case "Dice1Side2":
                    print("Dice 1: 5");
                    break;
                case "Dice1Side3":
                    print("Dice 1: 4");
                    break;
                case "Dice1Side4":
                    print("Dice 1: 3");
                    break;
                case "Dice1Side5":
                    print("Dice 1: 2");
                    break;
                case "Dice1Side6":
                    print("Dice 1: 1");
                    break;
            }
        }
        if(dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f){
            switch(col.gameObject.name){
                case "Dice2Side1":
                    print("Dice 2: 6");
                    break;
                case "Dice2Side2":
                    print("Dice 2: 5");
                    break;
                case "Dice2Side3":
                    print("Dice 2: 4");
                    break;
                case "Dice2Side4":
                    print("Dice 2: 3");
                    break;
                case "Dice2Side5":
                    print("Dice 2: 2");
                    break;
                case "Dice2Side6":
                    print("Dice 2: 1");
                    break;
            }
        }
    }

}
