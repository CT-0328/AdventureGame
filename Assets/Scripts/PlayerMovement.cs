using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody rb;
  [Range(0, 20)]
  public float speed;
  [Range(0, 10)]
  public float jumpForce;
  private groundCheck gc;
  private Hand hand;

    void Start()
    {
      hand = GetComponentInChildren<Hand>();
      gc = GetComponentInChildren<groundCheck>();
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      // Did player left click?
      if(Input.GetMouseButtonDown(0))
      {
        hand.attemptSwing();
      }

      // Movement
      float forwardBackward = Input.GetAxis("Vertical") * speed;
      float leftRight = Input.GetAxis("Horizontal") * speed;
      forwardBackward *= Time.deltaTime;
      leftRight *= Time.deltaTime;
      transform.Translate(leftRight, 0, forwardBackward);

      // Jump
      if(Input.GetButtonDown("Jump") && gc.isGrounded)
      {
        rb.AddForce(0, jumpForce * 100, 0);
      }
    }
}
