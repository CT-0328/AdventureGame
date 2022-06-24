using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IEquipment
{
  private Hand playerHand;
  public Collider weaponCollider;

  public GameObject GetGameObject()
  {
    return gameObject;
  }

  public Transform GetTransform()
  {
    return gameObject.transform;
  }

  public Collider GetDamageCollider()
  {
    return weaponCollider;
  }

  private void OnTriggerStay(Collider collider)
  {
    // Pick sword up if Q is pressed
    if(Input.GetKeyDown(KeyCode.Q))
    {
      playerHand = collider.GetComponentInChildren<Hand>();
      playerHand.EquipToHand(this);
    }
  }
}

public interface IEquipment
{
  Collider GetDamageCollider();
  GameObject GetGameObject();
  Transform GetTransform();
}
