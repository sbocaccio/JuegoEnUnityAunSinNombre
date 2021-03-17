using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barColour : MonoBehaviour
{
    public Image bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void colourBarCheck()
    {
        bar.color = Color.Lerp(Color.red, Color.green, bar.fillAmount);
    }
}
