using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{


  //int isWalkingHash;
  //int isRunningHash;
  Animator animator;
  float velocity = 0.0f;
  public float acceleration = 0.1f;
  public float deceleration = 0.5f;
  int VelocitHash;
  void Start()
  {
    animator = GetComponent<Animator>();
    //isWalkingHash = Animator.StringToHash("isWalking");
    //isRunningHash = Animator.StringToHash("isRunning");
    VelocitHash = Animator.StringToHash("Velocity");
  }

  // Update is called once per frame
  void Update()
  {

    //bool isRunning = animator.GetBool(isRunningHash);
    //bool isWalking = animator.GetBool(isWalkingHash);
    bool forwardPressed = Input.GetKey("w");
    bool runPressed = Input.GetKey("left shift");

    if (forwardPressed && velocity < 1.0f)
    {
      velocity += Time.deltaTime * acceleration;
    }
    if (!forwardPressed && velocity > 0.0f)
    {
      velocity -= Time.deltaTime * deceleration;
    }
    if (!forwardPressed && velocity < 0.0f)
    {
      velocity = 0.0f;
    }
    animator.SetFloat(VelocitHash, velocity);

  }
}
