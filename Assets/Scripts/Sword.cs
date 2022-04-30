using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
  private Hand playerHand;

  private void OnTriggerStay(Collider collider)
  {
    // Pick sword up if Q is pressed
    if(Input.GetKeyDown(KeyCode.Q))
    {
      playerHand = collider.GetComponentInChildren<Hand>();
      playerHand.EquipToHand(gameObject);
    }
  }
}
