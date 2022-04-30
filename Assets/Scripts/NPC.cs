using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
  public TextMeshPro pressE;
  public int index;
  public List<string> messages = new List<string>();

  public void toggleText(bool isToggle)
  {
    pressE.gameObject.SetActive(isToggle);
  }

  public void Talk()
  {
    pressE.text = messages[index];

    if(index < messages.Count)
      index++;
  }
}
