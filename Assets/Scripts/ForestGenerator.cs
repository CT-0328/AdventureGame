using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
  private Transform currentTree;
  private float Zrandomness;
  private float Xrandomness;
  [Range(0, 200)]
  public float ZrandomnessScale;
  [Range(0, 200)]
  public float XrandomnessScale;
  [Range(0, 100)]
  public float treeSpread;
  [Range(0, 100)]
  public float offset = 60f;

  [ContextMenu("ACTIVATE FOREST")]
  public void randomizeForest()
  {
    int sideLength = CalculateSideOfBox(transform.childCount);
    for(int i = 0; i < transform.childCount; i++)
    {
      Zrandomness = Random.Range(-ZrandomnessScale, ZrandomnessScale);
      Xrandomness = Random.Range(-XrandomnessScale, XrandomnessScale);
      currentTree = transform.GetChild(i);
      currentTree.position = new Vector3((i * treeSpread) % sideLength + Xrandomness + offset, 0, (i * treeSpread) / sideLength + 1 + Zrandomness + offset);
    }
  }

  public int CalculateSideOfBox(int things)
  {
    float sqrt = Mathf.Sqrt(things);
    int rnded = Mathf.CeilToInt(sqrt);
    return rnded;
  }
}
