using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour
{
    
    // Hand Controller
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources any = SteamVR_Input_Sources.Any;
    
    // Trigger Button
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    // TrackPad Touch True/False
    private SteamVR_Action_Boolean trackPadTouch;
    // TrackPad Position (x,y) Vector2
    private SteamVR_Action_Vector2 trackPadPosition;
    // Heptic
    private SteamVR_Action_Vibration haptic;


    // Start is called before the first frame update
    void Start()
    {
        leftHand = SteamVR_Input_Sources.LeftHand;
        rightHand = SteamVR_Input_Sources.RightHand;
        any = SteamVR_Input_Sources.Any;
        
        trigger = SteamVR_Actions.default_InteractUI;
        trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
        trackPadPosition = SteamVR_Actions.default_TrackPadPosition;
        haptic = SteamVR_Actions.default_Haptic;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(leftHand))
        {
            Debug.Log("Left hand trigger down");
            haptic.Execute(0.2f, 0.3f, 50.0f, 0.5f, leftHand);
        }
        if (trigger.GetState(rightHand))
        {
            Debug.Log($"Right Hand trigger click = {Time.time}");
        }
        if (trackPadTouch.GetState(rightHand))
        {
            Vector2 pos = trackPadPosition.GetAxis(rightHand);
            Debug.Log($"Touch Pos = {pos.x}/{pos.y}");
        }

        /*
            SteamVR_Actions.{ActionSet}_{BindMapping}.GetStateDown({Controller})
            GetState()
            GetStateUp()
            GetStateDown()
        */

        // if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_sources.LeftHand))
        // {
        //     Debug.Log("Trigger Left Hand")
        // }
    }
}
