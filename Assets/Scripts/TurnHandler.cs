using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    public int playerTurn = 0;
    public Player[] players;
    public BoardNavigation board;
    public Dice1Script diceOne;
    public Dice1Script diceTwo;
    public int overallDiceResult;

    public Vector3 nextZone;

    public bool rollSession;
    public bool moveSession;
    public bool buySession;
    public bool endingSession;


    private void Update()
    {
        if (rollSession)
            CheckDice();
        if (moveSession)
            MovePlayer();
        if (buySession)
            TakeAction();
        if (endingSession)
            AfterTurn();
    }

    public void RollDice()
    {
        MoveScript moveScript = players[playerTurn].GetComponent<MoveScript>();
        moveScript.Move(MoveScript.Direction.FORWARD);
        AfterTurn();
    }

    public void CheckDice()
    {
        //Debug.Log("CheckDice init");
        if (diceOne.isStopped && diceTwo.isStopped)
        {
            overallDiceResult = diceOne.diceResult + diceTwo.diceResult;
            players[playerTurn].targetZone = players[playerTurn]._position + overallDiceResult;
            nextZone = board.boardElements[players[playerTurn]._position + 1].transform.position;
            Debug.Log(nextZone);
            rollSession = false;
            moveSession = true;
            buySession = false;
            endingSession = false;
        }
    }

    public void TimeEnded()
    {
        Debug.Log("Time has ended random action selecting!!!");
        AfterTurn();
    }

    void AfterTurn()
    {
        Debug.Log("AfterTurn init");

        playerTurn = (playerTurn + 1) % players.Length;
        TurnTimer turnTimer = GetComponent<TurnTimer>();
        turnTimer.ResetTimer();
    }

    void MovePlayer()
    {
        //Debug.Log("MovePlayer init");

        players[playerTurn].transform.position =
            Vector3.MoveTowards(players[playerTurn].transform.position, nextZone, Time.deltaTime * 10f);
        if ((nextZone - players[playerTurn].transform.position).magnitude < 1f)
        {
            players[playerTurn]._position++;
            if (players[playerTurn]._position == players[playerTurn].targetZone)
            {
                players[playerTurn].transform.position = nextZone + new Vector3(playerTurn % players.Length + 2f,0,0);

                rollSession = false;
                moveSession = false;
                buySession = true;
                endingSession = false;
            }
            else
            {
                nextZone = board.boardElements[players[playerTurn]._position + 1].transform.position;
            }
        }
    }

    void TakeAction()
    {
        Debug.Log("TakeAction init");
    }
}