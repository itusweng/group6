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

  private bool rollSession;
  private bool moveSession;
  private bool buySession;
  private bool endingSession;
  
  private void Update()
  {
    if(rollSession)
      CheckDice();
    if(moveSession)
      MovePlayer();
    if(endingSession)
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
    if (diceOne.isStopped && diceTwo.isStopped)
    {
      overallDiceResult = diceOne.diceResult + diceTwo.diceResult;
      players[playerTurn].targetZone = players[playerTurn]._position + overallDiceResult;
      nextZone = board.boardElements[players[playerTurn]._position + 1].transform.position;
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
    playerTurn = (playerTurn + 1) % players.Length;
    TurnTimer turnTimer = GetComponent<TurnTimer>();
    turnTimer.ResetTimer();
  }

  void MovePlayer()
  {
    players[playerTurn].transform.position = Vector3.MoveTowards(transform.position, nextZone, Time.deltaTime * 3f);
    if ((nextZone - transform.position).magnitude < 1f)
    {
      players[playerTurn]._position++;
      if (players[playerTurn]._position == players[playerTurn].targetZone)
      {
        players[playerTurn].transform.position = nextZone + new Vector3((playerTurn + 1) % players.Length + 2f,
          transform.position.y, transform.position.z);
        
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
    
  }
  
  
}
