using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagePathResolver : MonoBehaviour, IChapterDispatcher
{
    //the player always starts out on a locator and then moves toward an action
    const string locator_W = "village_locator_west";
    const string locator_E = "village_locator_east";
    const string locator_NE = "village_locator_NE";
    const string locator_NPC = "village_locator_NPC";

    const string to_field_action = "village_to_fields_action";
    const string to_beach_action = "village_to_beach_action";
    const string to_house_action = "village_to_house_action";
    const string to_NPC_action = "village_to_NPC_action";

    [SerializeField]
    private Transform[] W_to_fields;

    [SerializeField]
    private Transform[] W_to_beach;

    [SerializeField]
    private Transform[] W_to_house;

    [SerializeField]
    private Transform[] W_to_NPC;

    [SerializeField]
    private Transform[] E_to_fields;

    [SerializeField]
    private Transform[] E_to_beach;

    [SerializeField]
    private Transform[] E_to_house;

    [SerializeField]
    private Transform[] E_to_NPC;

    [SerializeField]
    private Transform[] NE_to_fields;

    [SerializeField]
    private Transform[] NE_to_beach;

    [SerializeField]
    private Transform[] NE_to_house;

    [SerializeField]
    private Transform[] NE_to_NPC;

    [SerializeField]
    private Transform[] NPC_to_fields;

    [SerializeField]
    private Transform[] NPC_to_beach;

    [SerializeField]
    private Transform[] NPC_to_house;

    [SerializeField]
    private Transform[] NPC_to_NPC;

    Dictionary<string, Transform[]> dispatch_lookup = new Dictionary<string, Transform[]>();

    void Start()
    {
        dispatch_lookup.Add(locator_W + "/" + to_beach_action, W_to_beach);
        dispatch_lookup.Add(locator_W + "/" + to_field_action, W_to_fields);
        dispatch_lookup.Add(locator_W + "/" + to_house_action, W_to_house);
        dispatch_lookup.Add(locator_W + "/" + to_NPC_action, W_to_NPC);

        dispatch_lookup.Add(locator_E + "/" + to_beach_action, E_to_beach);
        dispatch_lookup.Add(locator_E + "/" + to_field_action, E_to_fields);
        dispatch_lookup.Add(locator_E + "/" + to_house_action, E_to_house);
        dispatch_lookup.Add(locator_E + "/" + to_NPC_action, E_to_NPC);

        dispatch_lookup.Add(locator_NE + "/" + to_beach_action, NE_to_beach);
        dispatch_lookup.Add(locator_NE + "/" + to_field_action, NE_to_fields);
        dispatch_lookup.Add(locator_NE + "/" + to_house_action, NE_to_house);
        dispatch_lookup.Add(locator_NE + "/" + to_NPC_action, NE_to_NPC);

        dispatch_lookup.Add(locator_NPC + "/" + to_field_action, NPC_to_fields);
        dispatch_lookup.Add(locator_NPC + "/" + to_beach_action, NPC_to_beach);
        dispatch_lookup.Add(locator_NPC + "/" + to_house_action, NPC_to_house);
        dispatch_lookup.Add(locator_NPC + "/" + to_NPC_action, NPC_to_NPC);
    }

    public Transform[] FindPath(string from, string to)
    {
        Transform[] result = new Transform[0];
        dispatch_lookup.TryGetValue(from + "/" + to, out result);
        return result;
    }
}
