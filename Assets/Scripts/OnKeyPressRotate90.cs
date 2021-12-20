using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPressRotate90 : MonoBehaviour
{
  public float speed = 100f;

  private Rotation rotation;
  private float remainingAngle;
  private bool rotating = false;


  private enum Rotation
  {
    COUNTERCLOCKWISE, CLOCKWISE
  }


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (rotating == false)
    {
      if (Input.GetKey(KeyCode.Q))
      {
        Debug.Log("Rotate CLOCKWISE");
        rotation = Rotation.CLOCKWISE;
        rotating = true;
        remainingAngle = 90;
      }
      if (Input.GetKey(KeyCode.E))
      {
        Debug.Log("Rotate COUNTERCLOCKWISE");
        rotation = Rotation.COUNTERCLOCKWISE;
        rotating = true;
        remainingAngle = 90;
      }
    }
    if (rotating == true)
    {
      Rotate();
    }
  }

  private void Rotate()
  {
    float amount = 0f;
    switch (rotation)
    {
      case Rotation.COUNTERCLOCKWISE:
        amount = Time.deltaTime * speed;
        transform.Rotate(0, amount, 0);
        remainingAngle -= Mathf.Abs(amount);
        break;
      case Rotation.CLOCKWISE:
        amount = Time.deltaTime * (-speed);
        transform.Rotate(0, amount, 0);
        remainingAngle -= Mathf.Abs(amount);
        break;
    }
    if (remainingAngle <= 0)
    {
      rotating = false;
    }
  }
}
