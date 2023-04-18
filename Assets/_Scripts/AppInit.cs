using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInit : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject locator;

    [SerializeField]
    GameObject Camera;

    [SerializeField]
    int chapterIndex;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = locator.transform.position;
        Camera.transform.position = new Vector3(chapterIndex * 60, -1, -1);
    }
}
