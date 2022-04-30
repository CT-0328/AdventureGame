using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
  public Transform goal;

  void Start()
  {
    StartCoroutine(dist());
  }

  void Update()
  {
    NavMeshAgent agent = GetComponent<NavMeshAgent>();

    if(Vector3.Distance(transform.position, goal.position) <= 3)
    {
      agent.SetDestination(transform.position);
    }
    else
    {
      agent.SetDestination(goal.position);
    }
  }
}
