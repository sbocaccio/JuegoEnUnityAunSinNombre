using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{

    public Text text;
    public static int coinAmount = 0;
    public void Start()
    {
        text = GameObject.FindGameObjectWithTag("MoneyScore").GetComponent<Text>();
    }
    // Start is called before the first frame update
    public void Increment( int amount)
    {

        coinAmount++;
        text.text = coinAmount.ToString();
 
    }
}
