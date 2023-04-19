using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceOrient : MonoBehaviour
{
    public Text outText;
    public Transform pointer;

    void Update()
    {
        outText.text = Input.deviceOrientation.ToString();
        switch (Input.deviceOrientation)
        {
            case DeviceOrientation.Portrait:
                pointer.eulerAngles = new Vector3(0, 0, 90);
                break;
            case DeviceOrientation.PortraitUpsideDown:
                pointer.eulerAngles = new Vector3(0, 0, -90);
                break;
            case DeviceOrientation.LandscapeLeft:
                pointer.eulerAngles = new Vector3(0, 0, 0);
                break;
            case DeviceOrientation.LandscapeRight:
                pointer.eulerAngles = new Vector3(0, 0, 180);
                break;
            default:
                break;
        }

    }

}
