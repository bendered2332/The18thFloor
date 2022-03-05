using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour
{
  Animator animator;
  float velocityZ = 0.0f;
  float velocityX = 0.0f;
  public float acceleration = 2.0f;
  public float deceleration = 2.0f;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    //input will be true if the player is pressing on the passed in key parameter
    //get key input from player
    bool forwardPressed = Input.GetKey("w");
    bool leftPressed = Input.GetKey("a");
    bool rightPressed = Input.GetKey("d");
    bool runPressed = Input.GetKey("left shift");

    //if player presses forward, increase velocity in z direction
    if (forwardPressed && velocityZ < 0.5f && !runPressed)
    {
      velocityZ += Time.deltaTime * acceleration;
    }

    //increase velocity in left direction
    if (leftPressed && velocityX > -0.5f && !runPressed)
    {
      velocityX -= Time.deltaTime * acceleration;
    }

    //increase velocity in right direction
    if (rightPressed && velocityX < 0.5f && !runPressed)
    {
      velocityX += Time.deltaTime * acceleration;
    }

    //decrease velocityZ
    if (!forwardPressed && velocityZ > 0.0f)
    {
      velocityZ -= Time.deltaTime * deceleration;
    }

    //reset velocitZ
    if (!forwardPressed && velocityZ < 0.0f)
    {
      velocityZ = 0.0f;
    }

    //increase velocityX if left is not pressed and velocityX < 0
    if (!leftPressed && velocityX < 0.0f)
    {
      velocityX += Time.deltaTime * deceleration;
    }

    //decrease velocityX if right is not pressed and velocityX > 0
    if (!rightPressed && velocityX < 0.0f)
    {
      velocityX -= Time.deltaTime * deceleration;
    }

    //reset velocityX
    if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
    {
      velocityX = 0.0f;
    }

    animator.SetFloat("Velocity Z", velocityZ);
    animator.SetFloat("Velocity X", velocityX);
  }
}
