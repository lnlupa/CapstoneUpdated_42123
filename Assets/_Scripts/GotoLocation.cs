using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoLocation : MonoBehaviour
{
    [SerializeField]
    private FollowPath player;

    void OnMouseDown()
    {
        IChapterDispatcher dispatch = null;
        GameObject o = this.gameObject;

        Debug.Log("STARTING " + dispatch + " => " + o);
        while ( dispatch == null && o != null )
        {
            dispatch = o.GetComponent<IChapterDispatcher>();
            Debug.Log("TRYING " + dispatch + " => " + o);
            if (o.transform.parent != null)
                o = o.transform.parent.gameObject;
            else
                break;
        }

        Transform[] myWp = new Transform[0];
        if ( dispatch != null )
        {
            Debug.Log("FOUND A DISPATCHER");
            Interact i = player.GetComponent<Interact>();
            if (i != null)
            {
                Debug.Log("CALLING FIND PATH");
                myWp = dispatch.FindPath(i.GetLocation(), this.name );
            }
            else
            {
                Debug.Log("No interact available");
            }
        }

        player.setWaypoints(myWp);
    }


}
