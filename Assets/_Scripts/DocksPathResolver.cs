using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocksPathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_SE = "docks_locator_SE";
    const string locator_NW = "docks_locator_NW";
    const string locator_NE = "docks_locator_NE";

    const string to_field_action = "docks_to_the_fields_action";
    const string to_beach_action = "docks_to_the_beach_action";
    const string to_hut_action = "docks_to_the_hut_action";


    [SerializeField]
    private Transform[] SE_to_beach;

    [SerializeField]
    private Transform[] SE_to_hut;

    [SerializeField]
    private Transform[] SE_to_fields;

    [SerializeField]
    private Transform[] NW_to_hut;

    [SerializeField]
    private Transform[] NW_to_fields;

    [SerializeField]
    private Transform[] NW_to_beach;

    [SerializeField]
    private Transform[] NE_to_beach;

    [SerializeField]
    private Transform[] NE_to_hut;

    [SerializeField]
    private Transform[] NE_to_fields;

    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();

    void Start()
    {
        dispatch_lookup.Add(locator_SE + "/" + to_beach_action, SE_to_beach);
        dispatch_lookup.Add(locator_SE + "/" + to_field_action, SE_to_fields);
        dispatch_lookup.Add(locator_SE + "/" + to_hut_action, SE_to_hut);

        dispatch_lookup.Add(locator_NW + "/" + to_beach_action, NW_to_beach);
        dispatch_lookup.Add(locator_NW + "/" + to_field_action, NW_to_fields);
        dispatch_lookup.Add(locator_NW + "/" + to_hut_action, NW_to_hut);

        dispatch_lookup.Add(locator_NE + "/" + to_beach_action, NE_to_beach);
        dispatch_lookup.Add(locator_NE + "/" + to_field_action, NE_to_fields);
        dispatch_lookup.Add(locator_NE + "/" + to_hut_action, NE_to_hut);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result );
        return result;
    }
}
