using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDBlendTreeAnimationStateController : MonoBehaviour
{
  Animator animator;
  float velocityX = 0.0f;
  float velocityZ = 0.0f;

  public float acceleration = 2.0f;
  public float deceleration = 2.0f;
  public float maximumWalkVelocity = 0.5f;
  public float maximumRunVelocity = 2.0f;

  // no magic numbers
  int zero = 0;
  float resetThreshold = 0.05f;

  // increasePerformance
  int velocityZHash;
  int velocityXHash;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();

    // set hash values
    velocityXHash = Animator.StringToHash("VelocityX");
    velocityZHash = Animator.StringToHash("VelocityZ");
  }

  // handles acceleration and deceleration
  void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
  {
    // if player presses forward, increase velocity in z direction
    if (forwardPressed && velocityZ < currentMaxVelocity)
    {
      velocityZ += Time.deltaTime * acceleration;
    }
    // if player presses left, increase velocity in left direction
    if (leftPressed && velocityX > -currentMaxVelocity)
    {
      velocityX -= Time.deltaTime * acceleration;
    }
    // if player presses right, increase velocity in right direction
    if (rightPressed && velocityX < currentMaxVelocity)
    {
      velocityX += Time.deltaTime * acceleration;
    }

    // decrease velocityZ
    if (!forwardPressed && velocityZ > zero)
    {
      velocityZ -= Time.deltaTime * deceleration;
    }

    // increase velocityX if left is not pressed and velocityX < 0
    if (!leftPressed && velocityX < zero)
    {
      velocityX += Time.deltaTime * deceleration;
    }
    // decrease velocityX if left is not pressed and velocityX < 0
    if (!rightPressed && velocityX > zero)
    {
      velocityX -= Time.deltaTime * deceleration;
    }
  }


  // handles reset and locking of velocity
  void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
  {
    // reset velocityZ
    if (!forwardPressed && velocityZ < zero)
    {
      velocityZ = zero;
    }

    // reset VelocityX
    if (!leftPressed && !rightPressed && velocityX != zero && (velocityX > -resetThreshold && velocityX < resetThreshold))
    {
      velocityX = zero;
    }

    // lock foward
    if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ = currentMaxVelocity;
      // decelerate to walk velocity
    }
    else if (forwardPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ -= Time.deltaTime * deceleration;
      // round to the currentMaxVelocity if within offset
      if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + resetThreshold))
      {
        velocityZ = currentMaxVelocity;
      }
    }
    // round to the currentMaxVelocity if within offset
    else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - resetThreshold))
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
      if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - resetThreshold))
      {
        velocityX = -currentMaxVelocity;
      }
    }
    // round to the currentMaxVelocity if within offset
    else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + resetThreshold))
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
      if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + resetThreshold))
      {
        velocityX = currentMaxVelocity;
      }
    }
    // round to the currentMaxVelocity if within offset
    else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - resetThreshold))
    {
      velocityX = currentMaxVelocity;
    }

  }

  // Update is called once per frame
  void Update()
  {
    // input will be true if the player is pressing on the passed in key parameter
    // get key input from player
    bool forwardPressed = Input.GetKey("w");
    bool leftPressed = Input.GetKey("a");
    bool rightPressed = Input.GetKey("d");
    bool runPressed = Input.GetKey("left shift");

    // set current max velocity
    float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

    // handles change in velocity
    changeVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
    lockOrResetVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);

    // set the parameters to our local variable values
    animator.SetFloat(velocityXHash, velocityX);
    animator.SetFloat(velocityZHash, velocityZ);
  }
}
