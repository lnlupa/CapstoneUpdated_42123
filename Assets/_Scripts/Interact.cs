using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private string currentLocation = "";

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"CollisionEnter2D {name} because a collision with {collision.collider.name}");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Transporter tr = collision.gameObject.GetComponent<Transporter>();
        if (tr != null)
        {
            Debug.Log($"Found transporter in {collision.gameObject.name}");
            tr.Transport(); 
            //return
            //copy block for dialogue class
            //make sure currentLocation is updated with the NPC
        }
        else
        {
            Debug.Log($"TriggerEnter2D {name} because a collision with {collision.gameObject.name}");
            currentLocation = collision.gameObject.name;

            Dialogue di = collision.gameObject.GetComponent<Dialogue>();
            if (di != null) 
            {
                di.OpenWindow();
            }
        }
    }

    public void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
    }

    public string GetLocation()
    {
        return currentLocation;
    }
}
