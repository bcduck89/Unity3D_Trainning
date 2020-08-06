using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabManager : MonoBehaviour
{

    private SteamVR_Action_Boolean grab;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Pose pose;

    private Transform grabObject;
    private bool isTouched;


    // Start is called before the first frame update
    void Start()
    {
        grab = SteamVR_Actions.default_GrabGrip;
        hand = SteamVR_Input_Sources.Any;
        pose = SteamVR_Actions.default_Pose;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched == true && grab.GetStateDown(hand))
        {
            grabObject.GetComponent<Rigidbody>().isKinematic = true;
            grabObject.SetParent(this.transform);
        }

        if (isTouched == true && grab.GetStateUp(hand))
        {
            grabObject.SetParent(null);
            grabObject.GetComponent<Rigidbody>().isKinematic = False;
            grabObject.GetComponent<Rigidbody>().velocity = pose.GetLastVelocity(hand);
            isTouched = false;
            grabObject = null;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
            grabObject = coll.transform;
        }
    }

}
