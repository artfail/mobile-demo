using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRot3D : MonoBehaviour
{
    private float rotationRate = 40;
    public LayerMask groundLayer;
    public LayerMask treeLayer;
    private Camera cam;
    private Transform tree;
    private bool treeSelected = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //Select Tree if touched
                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(touch.position), out hit, 100, treeLayer))
                {
                    if (treeSelected)
                    {
                        tree.GetComponent<TreeSelected>().Select(false);
                    }
                    tree = hit.transform;
                    tree.GetComponent<TreeSelected>().Select(true);
                    treeSelected = !ReferenceEquals(tree, null);
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                //deselect tree if touch ended
                if (treeSelected)
                {
                    tree.GetComponent<TreeSelected>().Select(false);
                }
                tree = null;
                treeSelected = false;
            }

            if (Input.touchCount == 1)
            {
                //move selected tree with 1 moving touch
                if (touch.phase == TouchPhase.Moved && treeSelected)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(cam.ScreenPointToRay(touch.position), out hit, 100, groundLayer))
                    {
                        tree.position = hit.point;
                    }
                }
            }
            else if (Input.touchCount > 1 && treeSelected)
            {
                // rotate selected tree with 2 moving touches
                if (touch.phase == TouchPhase.Moved)
                {
                    tree.Rotate(0, touch.deltaPosition.x * -rotationRate * Time.deltaTime, 0, Space.Self);
                }
            }
        }
    }
}
