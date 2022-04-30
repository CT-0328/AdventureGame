using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
  private float distanceToGround;
  public bool isGrounded = false;

  void Start()
  {
    distanceToGround = GetComponent<Collider>().bounds.extents.y;
  }

  void Update()
  {
    if(Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f))
    {
      isGrounded = true;
    }
    else
    {
      isGrounded = false;
    }
  }
}
