using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField]
    private int NewSceneIndex;

    [SerializeField]
    private Transform NewSceneLocator;

    [SerializeField]
    private Transform Camera;

    [SerializeField]
    private UnityEngine.GameObject Player;

    public void Transport()
    {
        Debug.Log("Transporting to " + NewSceneIndex);
        Player.transform.position = NewSceneLocator.transform.position;
        Camera.transform.position = new Vector3(NewSceneIndex * 60, -1, -1);
        FollowPath fp = Player.GetComponent<FollowPath>();
        if (fp != null)
        {
            Debug.Log("Clearing waypoints");
            fp.clearWaypoints();
        }
    }
}
