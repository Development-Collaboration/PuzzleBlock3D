using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material m_material;

    [SerializeField] private bool isDissolving = false;

    [SerializeField] private float fadeSpeed = 1f;

    // default (Display full object)
    private float fade = 0f;

    private void Awake()
    {
        //material = GetComponent<Material>();

        m_material = GetComponent<MeshRenderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Dissolve Pressed");
            //m_material.SetFloat("Fade", 0.6f);

            //print(m_material.GetColor("BaseColor"));

            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Fade",1f);

            //print(m_material.GetFloat("Fade"));
        }

        if (isDissolving)
        {
            fade += fadeSpeed * Time.deltaTime;


            if(fade >= 1f)
            {
                isDissolving = false;
                fade = 0f;
            }


            m_material.SetFloat("_Fade", fade);
        }



    }
}
