using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accel : MonoBehaviour
{
    public Text outText;

    void Update()
    {
        outText.text = "Acceleration Vector \n" + Input.acceleration.ToString();
    }
}