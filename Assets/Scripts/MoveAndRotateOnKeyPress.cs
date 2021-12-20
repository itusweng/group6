using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateOnKeyPress : MonoBehaviour
{

  public float moveSpeed = 10f;

  public float rotationSpeed = 100f;

  private enum Direction
  {
    FORWARD, BACK, LEFT, RIGHT
  }

  private enum Rotation
  {
    COUNTERCLOCKWISE, CLOCKWISE
  }

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Merhaba!");
    Rigidbody rigidBody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      Debug.Log("Forward Move");
      moveObject(Direction.FORWARD);
    }
    if (Input.GetKey(KeyCode.A))
    {
      Debug.Log("Left Move");
      moveObject(Direction.LEFT);
    }
    if (Input.GetKey(KeyCode.S))
    {
      Debug.Log("Back Move");
      moveObject(Direction.BACK);
    }
    if (Input.GetKey(KeyCode.D))
    {
      Debug.Log("Right Move");
      moveObject(Direction.RIGHT);
    }
    if (Input.GetKey(KeyCode.Q))
    {
      Debug.Log("Rotate CLOCKWISE");
      rotateObject(Rotation.CLOCKWISE);
    }
    if (Input.GetKey(KeyCode.E))
    {
      Debug.Log("Rotate COUNTERCLOCKWISE");
      rotateObject(Rotation.COUNTERCLOCKWISE);
    }
  }

  private void moveObject(Direction direction)
  {
    switch (direction)
    {
      case Direction.FORWARD:
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        break;
      case Direction.BACK:
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        break;
      case Direction.LEFT:
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        break;
      case Direction.RIGHT:
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        break;
    }
  }

  private void rotateObject(Rotation rotation)
  {
    switch (rotation)
    {
      case Rotation.COUNTERCLOCKWISE:
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
        break;
      case Rotation.CLOCKWISE:
        transform.Rotate(0, Time.deltaTime * (-rotationSpeed), 0);
        break;
    }
  }
}
