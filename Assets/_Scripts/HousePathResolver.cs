using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_C = "house_locator_central";
    const string locator_OBJ = "house_locator_obj";

    const string to_village_action = "house_east_action";
    const string to_docks_action = "house_west_action";
    const string to_OBJ_action = "house_obj_action";

    [SerializeField]
    private Transform[] to_village_east;

    [SerializeField]
    private Transform[] to_docks_west;

    [SerializeField]
    private Transform[] to_obj;

    [SerializeField]
    private Transform[] obj_to_docks;

    [SerializeField]
    private Transform[] obj_to_village;

    [SerializeField]
    private Transform[] obj_to_obj;

    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();

    void Start()
    {
        dispatch_lookup.Add(locator_C + "/" + to_village_action, to_village_east);
        dispatch_lookup.Add(locator_C + "/" + to_docks_action, to_docks_west);
        dispatch_lookup.Add(locator_C + "/" + to_OBJ_action, to_obj);

        dispatch_lookup.Add(locator_OBJ + "/" + to_docks_action, obj_to_docks);
        dispatch_lookup.Add(locator_OBJ + "/" + to_village_action, obj_to_village);
        dispatch_lookup.Add(locator_OBJ + "/" + to_OBJ_action, obj_to_obj);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result);
        return result;
    }

    /*public Transform[] FindPath(string from, string to)
    {
        if (to.Equals("house_west_action"))
            return to_docks_west;
        else
            return to_village_east;
    }*/
}
