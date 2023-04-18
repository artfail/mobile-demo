using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSelected : MonoBehaviour
{
    public Material selectedMat;
    private Renderer[] renderers;
    private Material[] baseMats;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        baseMats = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            baseMats[i] = renderers[i].material;
        }
    }

    public void Select(bool selected)
    {
        if (selected)
        {
            foreach (Renderer rend in renderers)
            {
                rend.material = selectedMat;
            }
        }
        else
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = baseMats[i];
            }
        }
    }

}
