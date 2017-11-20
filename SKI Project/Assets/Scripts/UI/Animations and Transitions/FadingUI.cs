using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingUI : MonoBehaviour {

    [SerializeField]
    Image PanelObject;
    [SerializeField]
    float FadeTime = 2;
    [SerializeField]
    bool isActive = false;
    Color currentColor;
    void Awake ()
    {
        PanelObject = GetComponent<Image>();
    }
    void Update()
    {// This Section is for Testing 
        currentColor = PanelObject.color;
        if (Input.GetKeyDown(KeyCode.E) &&  PanelObject.color.a >= 1.0f)
        {
            FadeOutUI();
        }
        if (Input.GetKeyDown(KeyCode.E) && PanelObject.color.a <= 0.03f)
        {
            FadeInUI();
        }
        //Above Section is for Testing
        
        if (PanelObject.color.a <= 0)
        {
            PanelObject.color = new Color(PanelObject.color.r, PanelObject.color.g, PanelObject.color.b, 0f);
        }
        if (PanelObject.color.a >= 1)
        {
            PanelObject.color = new Color(PanelObject.color.r, PanelObject.color.g, PanelObject.color.b, 1f);
            StopCoroutine(FadeInUI(PanelObject, FadeTime));
        }
    }

    void FixedUpdate ()
    {
        Debug.Log(isActive);
        Debug.Log(PanelObject.color.a);
    }

    public IEnumerator FadeOutUI(Image img, float time)
    {
        img.color = currentColor;
        while (PanelObject.color.a > 0.0f)
        {
            if (PanelObject.color.a >= 0)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / time));
            }
            
            if (PanelObject.color.a <= 0.1f)
            { this.gameObject.SetActive(false);}
            yield return null;
         
            isActive = true;


        }
    }

    public IEnumerator FadeInUI(Image img, float time)
    {
        img.color = currentColor;
        while (PanelObject.color.a < 1f)
        {
            if (PanelObject.color.a >= 0)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a + (Time.deltaTime / time));
            }
      
            
            yield return null;
           
            isActive = false;


        }
    }

    public void FadeOutUI ()
    {
        StartCoroutine(FadeOutUI(PanelObject, FadeTime));
    }

    public void FadeInUI ()
    {

        StartCoroutine(FadeInUI(PanelObject, FadeTime));
    }
}
