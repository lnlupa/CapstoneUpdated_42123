using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachPathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_N = "beach_locator_north";
    const string locator_W = "beach_locator_west";
    const string locator_E = "beach_locator_east";
    const string locator_OBJ = "beach_locator_obj";

    const string to_docks_action = "beach_to_the_docks_action";
    const string to_forest_action = "beach_to_the_forest_action";
    const string to_village_action = "beach_to_village_action";
    const string to_obj_action = "beach_to_obj_action";

    [SerializeField]
    private Transform[] N_to_docks;

    [SerializeField]
    private Transform[] N_to_forest;

    [SerializeField]
    private Transform[] N_to_village;

    [SerializeField]
    private Transform[] N_to_obj;

    [SerializeField]
    private Transform[] W_to_docks;

    [SerializeField]
    private Transform[] W_to_forest;

    [SerializeField]
    private Transform[] W_to_village;

    [SerializeField]
    private Transform[] W_to_obj;

    [SerializeField]
    private Transform[] E_to_docks;

    [SerializeField]
    private Transform[] E_to_forest;

    [SerializeField]
    private Transform[] E_to_village;

    [SerializeField]
    private Transform[] E_to_obj;

    [SerializeField]
    private Transform[] OBJ_to_docks;

    [SerializeField]
    private Transform[] OBJ_to_forest;

    [SerializeField]
    private Transform[] OBJ_to_village;

    [SerializeField]
    private Transform[] OBJ_to_obj;

    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();

    void Start()
    {
        dispatch_lookup.Add(locator_N + "/" + to_docks_action, N_to_docks);
        dispatch_lookup.Add(locator_N + "/" + to_forest_action, N_to_forest);
        dispatch_lookup.Add(locator_N + "/" + to_village_action, N_to_village);
        dispatch_lookup.Add(locator_N + "/" + to_obj_action, N_to_obj);

        dispatch_lookup.Add(locator_W + "/" + to_docks_action, W_to_docks);
        dispatch_lookup.Add(locator_W + "/" + to_forest_action, W_to_forest);
        dispatch_lookup.Add(locator_W + "/" + to_village_action, W_to_village);
        dispatch_lookup.Add(locator_W + "/" + to_obj_action, W_to_obj);

        dispatch_lookup.Add(locator_E + "/" + to_docks_action, E_to_docks);
        dispatch_lookup.Add(locator_E + "/" + to_forest_action, E_to_forest);
        dispatch_lookup.Add(locator_E + "/" + to_village_action, E_to_village);
        dispatch_lookup.Add(locator_E + "/" + to_obj_action, E_to_obj);

        dispatch_lookup.Add(locator_OBJ + "/" + to_docks_action, OBJ_to_docks);
        dispatch_lookup.Add(locator_OBJ + "/" + to_forest_action, OBJ_to_forest);
        dispatch_lookup.Add(locator_OBJ + "/" + to_village_action, OBJ_to_village);
        dispatch_lookup.Add(locator_OBJ + "/" + to_obj_action, OBJ_to_obj);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result);
        return result;
    }

    /*public Transform[] FindPath(string from, string to)
    {
        //Only one origin, we can dispatch directly
        switch (to)
        {
            case "beach_to_the_forest_action":
                return to_forest;
            case "beach_to_the_docks_action":
                return to_docks;
            case "beach_to_village_action":
                return to_village;
        }
        return new Transform[0];
    }*/
}
