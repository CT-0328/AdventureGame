using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckForNPC : MonoBehaviour
{
  private NPC targetNPC;
  private bool nearNPC;

  private void OnTriggerStay(Collider collider)
  {
    // Did we enter an NPC's collider?
    if(collider.gameObject.tag == "NPC")
    {
      // Make NPC able to interact
      nearNPC = true;

      if(targetNPC != null)
        targetNPC.toggleText(false);

      // Set targetNPC to most recent NPC we collided with
      targetNPC = collider.gameObject.GetComponent<NPC>();

      // Activate interact prompt text
      targetNPC.toggleText(true);
    }
  }

  void Update()
  {
    if(targetNPC != null)
    {
      // Make NPC look at player
      targetNPC.transform.LookAt(transform);
    }

    if(Input.GetKeyDown(KeyCode.E) && nearNPC)
    {
      // talk
      targetNPC.toggleText(true);
      targetNPC.Talk();
    }
  }

  private void OnTriggerExit(Collider collider)
  {
    if(targetNPC != null)
    {
      if(targetNPC.gameObject == collider.gameObject)
      {
        // Make NPC not able to interact
        nearNPC = false;

        // Deactivate interact prompt text
        targetNPC.toggleText(false);

        // Set targetNPC to nothing
        targetNPC = null;
      }
    }
  }
}
