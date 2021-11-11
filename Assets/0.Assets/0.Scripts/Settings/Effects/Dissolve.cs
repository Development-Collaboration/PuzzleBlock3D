using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]

public class Dissolve : MonoBehaviour
{
    private Material m_material;

    [SerializeField] private bool isDissolving = false;

    [SerializeField] private float fadeSpeed = 0.05f;

    // default (Display full object)
    private float fade = 0f;

    private float maxFade = 1f;
    private float minFade = 0f;

    private void Awake()
    {
        //material = GetComponent<Material>();

        m_material = GetComponent<MeshRenderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(isDissolving)
        {
            StartCoroutine(FadeOut());
        }
        else
            StartCoroutine(FadeIn());
    }
    */

    public void Dissolving()
    {
        if (isDissolving)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {

        while(fade <= maxFade)
        {
            fade += fadeSpeed * Time.deltaTime;

            m_material.SetFloat("_Fade", fade);
            yield return null;
        }

        fade = maxFade;
        m_material.SetFloat("_Fade", fade);

        //isDissolving = true;

        yield return null;
    }

    IEnumerator FadeIn()
    {

        while (fade >= minFade)
        {
            fade -= fadeSpeed * Time.deltaTime;

            m_material.SetFloat("_Fade", fade);
            yield return null;
        }

        fade = minFade;
        m_material.SetFloat("_Fade", fade);

        //isDissolving = false;

        yield return null;
    }


}
