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
  private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
  private Vector3 originalScale;
  private bool crouch;
  private float topSpeed = 15;

    void Start()
    {
      originalScale = transform.localScale;
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

      if(Input.GetKeyDown(KeyCode.LeftShift))
      {
        crouch = !crouch;
        if(crouch)
        {
          speed = topSpeed/2;
        }
        if(crouch == false)
        {
          speed = topSpeed;
        }
      }

      if(crouch)
      {
        Crouch();
      }
      if(crouch == false)
      {
        Uncrouch();
      }

      // Movement
      float forwardBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
      float leftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
      transform.Translate(leftRight, 0, forwardBackward);

      // Jump
      if(Input.GetButtonDown("Jump") && gc.isGrounded)
      {
        rb.AddForce(0, jumpForce * 100, 0);
      }
    }

    public void Crouch()
    {
      // move the camera/player to be lower
      transform.localScale = crouchScale;
    }
    public void Uncrouch()
    {
      transform.localScale = originalScale;
    }
}
