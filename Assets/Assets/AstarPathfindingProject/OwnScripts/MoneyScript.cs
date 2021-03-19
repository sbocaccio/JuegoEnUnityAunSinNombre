using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{

    public Text text;
    public static int coinAmount = 0;
    // Start is called before the first frame update
    public void Increment( int amount)
    {

        coinAmount++;
        text.text = coinAmount.ToString();
    }
}
