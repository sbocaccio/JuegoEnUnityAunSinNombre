using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip2 : MonoBehaviour
{
    public int valor; 
    // Start is called before the first frame update
    void Start()
    {
        valor = gameObject.GetComponent<script1>().giveValue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tengo valor y es" + valor);
    }
}
