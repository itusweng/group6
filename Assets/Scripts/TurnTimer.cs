using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{
  public Text remainingTimeText;

  public float initialTimeLeft = 60f;
  float timeLeft;

  // Start is called before the first frame update
  void Start()
  {
    timeLeft = initialTimeLeft;
  }

  // Update is called once per frame
  void Update()
  {
    if (timeLeft <= 0)
    {
      TurnHandler turnHandler = GetComponent<TurnHandler>();
      turnHandler.TimeEnded();
    }
    else
    {
      timeLeft -= Time.deltaTime;
      remainingTimeText.text = "Time remaining: " + timeLeft.ToString("00");
    }
  }

  public void ResetTimer()
  {
    timeLeft = initialTimeLeft;
  }
}
