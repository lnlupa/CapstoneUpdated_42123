using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_E = "forest_locator_east";
    const string locator_W = "forest_locator_west";
    const string locator_NPC = "forest_locator_NPC";

    const string to_beach_action = "forest_to_the_beach_action";
    const string to_fields_action = "forest_to_the_fields_action";
    const string to_NPC_action = "forest_to_NPC_action";

    [SerializeField]
    private Transform[] west_to_beach;

    [SerializeField]
    private Transform[] west_to_fields;

    [SerializeField]
    private Transform[] west_to_NPC;

    [SerializeField]
    private Transform[] east_to_beach;

    [SerializeField]
    private Transform[] east_to_fields;

    [SerializeField]
    private Transform[] east_to_NPC;

    [SerializeField]
    private Transform[] NPC_to_beach;

    [SerializeField]
    private Transform[] NPC_to_fields;

    [SerializeField]
    private Transform[] NPC_to_NPC;

    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();
    void Start()
    {
        dispatch_lookup.Add(locator_NPC + "/" + to_beach_action, NPC_to_beach);
        dispatch_lookup.Add(locator_NPC + "/" + to_fields_action, NPC_to_fields);
        dispatch_lookup.Add(locator_NPC + "/" + to_NPC_action, NPC_to_NPC);

        dispatch_lookup.Add(locator_E + "/" + to_beach_action, east_to_beach);
        dispatch_lookup.Add(locator_E + "/" + to_fields_action, east_to_fields);
        dispatch_lookup.Add(locator_E + "/" + to_NPC_action, east_to_NPC);

        dispatch_lookup.Add(locator_W + "/" + to_beach_action, west_to_beach);
        dispatch_lookup.Add(locator_W + "/" + to_fields_action, west_to_fields);
        dispatch_lookup.Add(locator_W + "/" + to_NPC_action, west_to_NPC);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result);
        return result;
    }

    /*public Transform[] FindPath(string from, string to)
    {
        if ( from.Equals("forest_locator_east"))
        { 
            if ( to.Equals("forest_to_the_beach_action"))
                return east_to_beach;
            return east_to_fields;
        }
        else
        {
            if (to.Equals("forest_to_the_beach_action"))
                return west_to_beach;
            return west_to_fields;
        }
    }*/
}

