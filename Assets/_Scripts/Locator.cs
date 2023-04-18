using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Locator : MonoBehaviour
{
    public static event Action DialogueInit;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("NPCLocator")) 
        {
            DialogueInit?.Invoke();
        }
    }
}
