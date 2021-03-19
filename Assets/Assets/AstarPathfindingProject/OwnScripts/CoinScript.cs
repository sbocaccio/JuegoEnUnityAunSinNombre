using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    MoneyScript money;
    // Start is called before the first frame update
    public void Start()
    {
        money = GetComponent<MoneyScript>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            money.Increment(1);
            Destroy(gameObject);
        }
    }

    
}
