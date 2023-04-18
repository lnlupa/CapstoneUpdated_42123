using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;

    [SerializeField]
    private string textContent;

    [SerializeField]
    private GameObject displayWindow;

    private Collider2D coll;

    private void Start()
    {
        Locator.DialogueInit += ActivateColl;
        coll = GetComponent<Collider2D>();
        //coll.enabled = false;
        displayText.text = textContent;
        displayWindow.SetActive(false);
    }

    public void OpenWindow() 
    {
        Debug.Log("Dialogue should happpen now");
        displayText.text = textContent;
        displayWindow.SetActive(true);
    }

    public void CloseWindow() 
    {
        displayWindow.SetActive(false);
    }

    private void ActivateColl() 
    {
        coll.enabled = true;
    }
}
