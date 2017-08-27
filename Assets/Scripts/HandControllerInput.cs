using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour
{
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    //Teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public GameObject floor;
    public LayerMask laserMask; //helps to determine WHERE you can teleport
    public LayerMask WallMask;
    public float yNudgeAmount = 3f; //specific to teleportAimerObject height
    public float xBumpAmount = 3f;
    public float zBumpAmount = 3f;
    public GameObject ball;

    //Dash
    public float dashSpeed = 0.1f;
    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;
    private Vector3 currentPosition;

    //
    public Transform playerCam;
    public float moveSpeed = 4f;
    private Vector3 movementDirection;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        /* if (device.GetPress(SteamVR_Controller.ButtonMask.Grip) & !isDashing)
        {
            movementDirection = playerCam.transform.forward;
            movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
            movementDirection = movementDirection * moveSpeed * Time.deltaTime;
            player.transform.position += movementDirection;
        }*/
        if (isDashing)
        {
            //Lerp takes 2 values and smoothes them over time based on a float variable
            lerpTime += 1 * dashSpeed;
            player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
            //Debug.Log("dash!");
            if (lerpTime >= 1)
            {
                //Debug.Log("lerp time was " + lerpTime);
                isDashing = false;
                lerpTime = 0;
                //Debug.Log("lerp time is " + lerpTime);
            }
        }
        if (!isDashing)
        {

            currentPosition = player.transform.position;
            //if holding button down -- can replace with touchpad
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                //Debug.Log("trigger pressed");
                laser.gameObject.SetActive(true);
                teleportAimerObject.SetActive(true);
                laser.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
                {
                    teleportLocation = hit.point;
                    teleportLocation.y = teleportLocation.y + yNudgeAmount;
                    //laser.SetPosition(1, teleportLocation);
                    //aimer position
                    teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y - yNudgeAmount, teleportLocation.z);
                    laser.SetPosition(1, teleportAimerObject.transform.position);
                    /*if (hit.collider.gameObject.layer == WallMask)
                    {
                        Debug.Log("Not moving");
                        teleportLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    }*/
                    if (hit.collider.gameObject.tag == "Barrier")
                    {
                        Debug.Log("Not moving - hit nothing");
                        teleportLocation = currentPosition;
                    }

                }
                else
                {
                    teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
                    RaycastHit groundRay;
                    if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                    {
                        teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, groundRay.point.y + yNudgeAmount, transform.forward.z * 15 + transform.position.z);
                    }
                    
                    //laser.SetPosition(1, transform.forward * 15 + transform.position);
                    teleportAimerObject.transform.position = teleportLocation + new Vector3(0, -yNudgeAmount, 0);
                    laser.SetPosition(1, teleportAimerObject.transform.position);
                }
            }
            //if releasing button
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);
                //player.transform.position = teleportLocation;
                dashStartPosition = player.transform.position;
                isDashing = true;
                
            }
        }
    }


}


/*if(hit.collider.gameObject.name == "NorthWall")
                    {
                        Debug.Log("North wall hit");
                        teleportLocation = new Vector3(hit.point.x, floor.transform.position.y + yNudgeAmount, hit.point.z - zBumpAmount);
                    }
                    if (hit.collider.gameObject.name == "SouthWall")
                    {
                        Debug.Log("South wall hit");
                        teleportLocation = new Vector3(hit.point.x, floor.transform.position.y + yNudgeAmount, hit.point.z + zBumpAmount);
                    }
                    if (hit.collider.gameObject.name == "EastWall")
                    {
                        Debug.Log("East wall hit");
                        teleportLocation = new Vector3(hit.point.x - xBumpAmount, floor.transform.position.y + yNudgeAmount, hit.point.z);
                    }
                    if (hit.collider.gameObject.name == "WestWall")
                    {
                        Debug.Log("West wall hit");
                        teleportLocation = new Vector3(hit.point.x + xBumpAmount, floor.transform.position.y + yNudgeAmount, hit.point.z);
                    }*/
