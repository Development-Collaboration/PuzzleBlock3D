using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    public bool isSwap = false;

    public Material[] materials;
    public float changeInterval = 0.33F;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       // if (materials.Length == 0)
       //     return;


        // we want this material index now
        int index = Mathf.FloorToInt(Time.time / changeInterval);

        // take a modulo with materials count so that animation repeats
        index = index % materials.Length;

        // assign it to the renderer
        rend.sharedMaterial = materials[index];

    }
}
