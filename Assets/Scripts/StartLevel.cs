using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

    public GameObject nextLevel;
    public SteamVR_TrackedObject trackedObj1;
    public SteamVR_TrackedObject trackedObj2;
    public SteamVR_Controller.Device device1;
    public SteamVR_Controller.Device device2;


    private void Update()
    {
        device1 = SteamVR_Controller.Input((int)trackedObj1.index);
        device2 = SteamVR_Controller.Input((int)trackedObj2.index);
        if (device1.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || device1.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            nextLevel.GetComponent<SteamVR_LoadLevel>().Trigger();
        }
    }

}
