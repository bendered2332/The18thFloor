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
  public float maximumWalkVelocity = 0.5f;
  public float maximumRunVelocity = 2.0f;
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

    //set current maxVelocity
    float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

    //if player presses forward, increase velocity in z direction
    if (forwardPressed && velocityZ < currentMaxVelocity)
    {
      velocityZ += Time.deltaTime * acceleration;
    }

    //increase velocity in left direction
    if (leftPressed && velocityX > -currentMaxVelocity)
    {
      velocityX -= Time.deltaTime * acceleration;
    }

    //increase velocity in right direction
    if (rightPressed && velocityX < currentMaxVelocity)
    {
      velocityX += Time.deltaTime * acceleration;
    }

    //decrease velocityZ
    if (!forwardPressed && velocityZ > 0.0f)
    {
      velocityZ -= Time.deltaTime * deceleration;
    }

    //reset velocityZ
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
    if (!rightPressed && velocityX > 0.0f)
    {
      velocityX -= Time.deltaTime * deceleration;
    }

    //reset velocityX
    if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
    {
      velocityX = 0.0f;
    }

    //lock forward
    if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ = currentMaxVelocity;
    }
    else if (forwardPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ -= Time.deltaTime * deceleration;
      if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
      {
        velocityZ = currentMaxVelocity;
      }
    }
    else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
    {
      velocityZ = currentMaxVelocity;
    }

    //lock forward
    if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ = currentMaxVelocity;
    }
    else if (forwardPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ -= Time.deltaTime * deceleration;
      if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
      {
        velocityZ = currentMaxVelocity;
      }
    }
    else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
    {
      velocityZ = currentMaxVelocity;
    }

    // lock left
    if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
    {
      velocityX = -currentMaxVelocity;
      // decelerate to walk velocity
    }
    else if (leftPressed && velocityX < -currentMaxVelocity)
    {
      velocityX += Time.deltaTime * deceleration;
      // round to the currentMaxVelocity if within offset
      if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
      {
        velocityX = -currentMaxVelocity;
      }
    }
    // round to the currentMaxVelocity if within offset
    else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
    {
      velocityX = -currentMaxVelocity;
    }

    // lock right
    if (rightPressed && runPressed && velocityX > currentMaxVelocity)
    {
      velocityX = currentMaxVelocity;
      // decelerate to walk velocity
    }
    else if (rightPressed && velocityX > currentMaxVelocity)
    {
      velocityX -= Time.deltaTime * deceleration;
      // round to the currentMaxVelocity if within offset
      if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
      {
        velocityX = currentMaxVelocity;
      }
    }
    // round to the currentMaxVelocity if within offset
    else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
    {
      velocityX = currentMaxVelocity;
    }

    animator.SetFloat("Velocity Z", velocityZ);
    animator.SetFloat("Velocity X", velocityX);
  }
}
