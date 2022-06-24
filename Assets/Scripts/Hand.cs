using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hand : MonoBehaviour
{
  private IEquipment equippedItem;
  private Animator anim;
  private bool isAttacking;

  void Start()
  {
    anim = GetComponent<Animator>();
    anim.speed = 2;
  }

  public void EquipToHand(IEquipment item)
  {
    // Save picked up item
    equippedItem = item;
    // Move and rotate item to look nice
    OrientItem(equippedItem);
  }

  public void attemptSwing()
  {
    if(isAttacking == false)
    {
      anim.SetTrigger("Swing");
    }
  }

  public void OrientItem(IEquipment item)
  {
    Transform equipmentTransform = item.GetTransform();
    // Parent item to hand so it will follow player
    equipmentTransform.parent = transform;
    // Teleport into player's hand
    equipmentTransform.position = transform.position;
    //equipmentTransform.position += new Vector3(0, -0.5f, 0);
    // Set rotation to look normal
    equipmentTransform.localRotation = Quaternion.identity;
  }

  public void TurnOnHitbox()
  {
     isAttacking = true;
    if(equippedItem != null)
    {
      equippedItem.GetDamageCollider().enabled = true;
    }
  }

  public void TurnOffHitbox()
  {
    isAttacking = false;
    if(equippedItem != null)
    {
      equippedItem.GetDamageCollider().enabled = false;
    }
  }
}
