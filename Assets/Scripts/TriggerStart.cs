using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStart : MonoBehaviour
{
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    public GameObject nextLevel;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            nextLevel.GetComponent<SteamVR_LoadLevel>().Trigger();
        }
    }
}

