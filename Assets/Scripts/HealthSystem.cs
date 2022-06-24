using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
  [Range(0, 100)]
  public float health = 100;
  public ParticleSystem thing;
  public IDamaging attacker;
  public UnityEvent onDeath;
  public UnityEvent<IDamaging> onTakeDamage;

    private void OnTriggerEnter(Collider collider)
    {
      attacker = collider.GetComponent<IDamaging>();
      health -= attacker.GetDamage();
      thing.Play();
      onTakeDamage.Invoke(attacker);

      if(health <= 0)
      {
        onDeath.Invoke();
      }
    }
}
