using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPressMove : MonoBehaviour
{

  public float speed = 10f;
  public float targetDistance = 5f;

  private Direction direction;
  private float remainingDistance;
  private bool moving = false;


  private enum Direction
  {
    FORWARD, BACK, LEFT, RIGHT
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (moving == false)
    {
      if (Input.GetKey(KeyCode.W))
      {
        Debug.Log("Forward Move");
        direction = Direction.FORWARD;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (Input.GetKey(KeyCode.A))
      {
        Debug.Log("Left Move");
        direction = Direction.LEFT;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (Input.GetKey(KeyCode.S))
      {
        Debug.Log("Back Move");
        direction = Direction.BACK;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (Input.GetKey(KeyCode.D))
      {
        Debug.Log("Right Move");
        direction = Direction.RIGHT;
        moving = true;
        remainingDistance = targetDistance;
      }
    }
    if (moving == true)
    {
      Move();
    }
  }

  private void Move()
  {
    float amount = 0f;
    switch (direction)
    {
      case Direction.FORWARD:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.forward * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.BACK:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.back * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.LEFT:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.left * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.RIGHT:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.right * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
    }
    if (remainingDistance <= 0)
    {
      moving = false;
    }
  }
}
