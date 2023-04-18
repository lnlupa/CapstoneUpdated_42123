using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagement : MonoBehaviour
{
    public GameObject menuWindow;

    public GameObject journalWindow;

    // Start is called before the first frame update
    void Start()
    {
        menuWindow.SetActive(false);
        journalWindow.SetActive(false);
    }

    public void MenuOn() 
    {
        menuWindow.SetActive(true);
    }

    public void MenuOff()
    {
        menuWindow.SetActive(false);
    }

    public void JournalOn()
    {
        journalWindow.SetActive(true);
    }

    public void JournalOff()
    {
        journalWindow.SetActive(false);
    }
}
