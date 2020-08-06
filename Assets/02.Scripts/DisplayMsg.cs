using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하기 위해서 필요한 라이브러리


public class DisplayMsg : MonoBehaviour
{
    
    private Text msgText;

    // Start is called before the first frame update
    void Start()
    {
        msgText = GetComponent<Text>();
    }

    public void Message(string msg)
    {
        msgText.text = msg;
    }
    
}
