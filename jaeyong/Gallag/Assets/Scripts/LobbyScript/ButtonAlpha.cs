using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlpha : MonoBehaviour
{
    GameObject Bt;
    Image im;
    // Start is called before the first frame update
    void Start()
    {
        Bt = GameObject.Find("Button");
        im = Bt.GetComponent<Image>();
    }

    // Update is called once per frame
    public void fadeout()
    {
        StartCoroutine("Fadeout");
    }
    public void fadein()
    {
        StartCoroutine("Fadein");
    }


    IEnumerator Fadeout()
    {
        for (float ff = 1.0f; ff >= 0.0f; ff -= 0.02f)
        {

            im.color = new Color(1,1,1, ff);
            yield return null;
        }
    }
    IEnumerator Fadein()
    {
        for (float ff = 0.0f; ff <= 1.0f; ff += 0.02f)
        {
            im.color = new Color(1, 1, 1, ff);
            yield return null;
        }
    }
}
