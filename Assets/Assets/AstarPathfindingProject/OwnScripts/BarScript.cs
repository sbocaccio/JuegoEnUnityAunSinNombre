using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Image healthBar;
    // Start is called before the first frame update
    private int maxFillPorcentage = 100;
    private int currentFillPorcentage;

    public void UnfillBar(int damageReceived)
    {
        currentFillPorcentage = Mathf.Clamp(currentFillPorcentage - damageReceived, 0, maxFillPorcentage);
    }

    void Start()
    {
        currentFillPorcentage = maxFillPorcentage;
    }

    // Update is called once per frame
    void Update()
    {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)(currentFillPorcentage) / (float)maxFillPorcentage, Time.deltaTime);
    }
}
