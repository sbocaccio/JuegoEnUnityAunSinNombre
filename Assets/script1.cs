using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour
{
    public int value = 5;

    public int giveValue()
    {
        Debug.Log("I'm giving the value" + value);
        return value;
    }


}
