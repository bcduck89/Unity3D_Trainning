using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Boolean trigger;
    private Transform tr;
    private RaycastHit hit;

    private LineRenderer line;

    public float maxDistance = 10.0f;
    public Color defaultColor = Color.green; // new Color (0.0f, 1.0f, 0.0f, 0.0f)
    public Color clickedColor = Color.red;

    private GameObject currButton = null;
    private GameObject prevButton = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        CreateLine();
    }

    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        // Start Point, End Point
        line.positionCount = 2;
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        line.startWidth = 0.95f;
        line.endWidth = 0.005f;

        line.numCapVertices = 20;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = defaultColor;


    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0.0f, 0.0f, hit.distance));

            currButton = hit.collider.gameObject;
            if (currButton != prevButton)
            {
                // Current Button Send Event
                ExecuteEvents.Execute(currButton
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerEnterHandler);

                // Previous Button Send Event
                ExecuteEvents.Execute(prevButton
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerExitHandler);
                prevButton = currButton;
            }
            else
            {
                if (prevButton != null)
                {
                    //Previous Button Send Event
                    ExeuteEvents.Execute( prevButton
                                        , new PointerEventData(EventSystem.current)
                                        , Executeevents.pointerExitHandler);

                    )
                }
            }
        }
    }
}
