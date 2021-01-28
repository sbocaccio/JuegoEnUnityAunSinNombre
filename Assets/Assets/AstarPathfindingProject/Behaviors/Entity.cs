using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Entity : MonoBehaviour, IKillable
{
    //[SerializeField]
    //private Image healthBar;
    [SerializeField]
    private int m_Health = 100;
    public int GetHealth()
    {
        return m_Health;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void TakeDamage (int damage)
    {
       
        m_Health -= damage;
       // healthBar.fillAmount = m_Health / 100f;
    }

    protected void EntityUpdate()
    {
        if (GetHealth() <= 0)
        {
            Kill();
        }
    }
}
