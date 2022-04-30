using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hand : MonoBehaviour
{
  private GameObject equippedItem;
  private Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
    anim.speed = 2;
  }

  public void EquipToHand(GameObject item)
  {
    // Save picked up item
    equippedItem = item;
    // Move and rotate item to look nice
    OrientItem(equippedItem);
  }

  public void attemptSwing()
  {
    anim.SetTrigger("Swing");
  }

  public void OrientItem(GameObject item)
  {
    // Parent item to hand so it will follow player
    item.transform.parent = transform;
    // Teleport into player's hand
    item.transform.position = transform.position;
    item.transform.position += new Vector3(0, -0.4f, 0);
    // Set scale to prevent squashing/stretching
    item.transform.localScale = new Vector3(1, 0.75f, 2);
    // Set rotation to look normal
    item.transform.localRotation = Quaternion.identity;
  }
}
