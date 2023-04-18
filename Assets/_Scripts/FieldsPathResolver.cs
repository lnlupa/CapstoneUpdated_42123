using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldsPathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_SW = "fields_locator_SW";
    const string locator_NW = "fields_locator_NW";
    const string locator_W = "fields_locator_W";

    const string to_docks_action = "fields_to_docks_action";
    const string to_forest_action = "fields_to_forest_action";
    const string to_village_action = "fields_to_village_action";

    [SerializeField]
    private Transform[] NW_to_docks;

    [SerializeField]
    private Transform[] NW_to_forest;

    [SerializeField]
    private Transform[] NW_to_village;

    [SerializeField]
    private Transform[] SW_to_docks;

    [SerializeField]
    private Transform[] SW_to_forest;

    [SerializeField]
    private Transform[] SW_to_village;

    [SerializeField]
    private Transform[] W_to_village;

    [SerializeField]
    private Transform[] W_to_forest;

    [SerializeField]
    private Transform[] W_to_docks;


    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();

    void Start()
    {
        dispatch_lookup.Add(locator_SW + "/" + to_docks_action, SW_to_docks);
        dispatch_lookup.Add(locator_SW + "/" + to_forest_action, SW_to_forest);
        dispatch_lookup.Add(locator_SW + "/" + to_village_action, SW_to_village);

        dispatch_lookup.Add(locator_NW + "/" + to_docks_action, NW_to_docks);
        dispatch_lookup.Add(locator_NW + "/" + to_forest_action, NW_to_forest);
        dispatch_lookup.Add(locator_NW + "/" + to_village_action, NW_to_village);

        dispatch_lookup.Add(locator_W + "/" + to_docks_action, W_to_docks);
        dispatch_lookup.Add(locator_W + "/" + to_forest_action, W_to_forest);
        dispatch_lookup.Add(locator_W + "/" + to_village_action, W_to_village);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result);
        return result;
    }

    /*public Transform[] FindPath(string from, string to)
    {
        Debug.Log("resolving " + from + "/" + to);
        if (from.Equals("fields_locator_SW"))
        {
            if (to.Equals("fields_to_docks_action"))
                return SW_to_docks;
            return SW_to_forest;
        }
        else
        {
            if (to.Equals("fields_to_docks_action"))
                return NW_to_docks;
            return NW_to_forest;
        }
    }*/

}