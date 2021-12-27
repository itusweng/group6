using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
  public int playerTurn = 0;
  public GameObject[] players;

  public void RollDice()
  {
    MoveScript moveScript = players[playerTurn].GetComponent<MoveScript>();
    moveScript.Move(MoveScript.Direction.FORWARD);
    AfterTurn();
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

}
