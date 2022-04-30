using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
  [Range(0, 100)]
  public float health = 100;
  public ParticleSystem thing;

    private void OnTriggerEnter(Collider collider)
    {
      health -= 10;
      thing.Play();

      if(health <= 0)
      {
        Debug.Log(collider.gameObject.name + " killed me!");
        Destroy(transform.parent.gameObject);
      }
    }
}
