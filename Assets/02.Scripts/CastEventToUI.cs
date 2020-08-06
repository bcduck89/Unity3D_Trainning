using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using Valve.VR;
using Valve.VR.Extras;

public class Test : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;
    // Start is called before the first frame update
    void Awake()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    void OnEnable() // script가 활성화 될때마다 호출된다. start는 딱 한번 호출된다. Awake -> OnEnable -> start 순
    {
        laserPointer.PointerIn += OnPointerEnter;
        laserPointer.PointerOut += OnPointerExit;
        // laserPointer.PointerClick += OnPointerClick;
    }

    void OnDisable() // script가 활성화 될때마다 호출된다. start는 딱 한번 호출된다. Awake -> OnEnable -> start 순
    {
        laserPointer.PointerIn -= OnPointerEnter;
        laserPointer.PointerOut -= OnPointerExit;
        // laserPointer.PointerClick -= OnPointerClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Laser Pointer Hover
    void OnPointerEnter(object sender, PointerEventArgs e)
    {
        IPointerEnterHandler handler = e.target.GetComponent<IPointerEnterHandler>();
        if (handler == null) return;

        handler.OnPointerEnter(new PointerEventData(EventSystem.current));
    }
    // Laser Pointer Exit
    void OnPointerExit(object sender, PointerEventArgs e)
    {
        IPointerExitHandler handler = e.target.GetComponent<IPointerExitHandler>();
        if (handler == null) return;

        handler.OnPointerExit(new PointerEventData(EventSystem.current));
    }
    // Laser Pointer Click
    void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler handler = e.target.GetComponent<IPointerClickHandler>();
        if (handler == null) return;

        handler.OnPointerClick(new PointerEventData(EventSystem.current));
    }

}
