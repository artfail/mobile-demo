using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubbleTap : MonoBehaviour
{
    public Text outText;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount > 0)
            {
                Vector2 worldPos = cam.ScreenToWorldPoint(touch.position);
                if (Physics2D.OverlapPoint(worldPos))
                {
                    outText.text = "You tapped " + Physics2D.OverlapPoint(worldPos).name + " " + touch.tapCount + " times!";
                }
                else
                {
                    outText.text = "You tapped the screen " + touch.tapCount + " times!";
                }
            }
        }
    }
}
