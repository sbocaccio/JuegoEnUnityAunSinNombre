using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    private Transform player_transform;
    Player player_script;
    Defence player_defence;

    [SerializeField]
    private float dist;
    [SerializeField]
    private float howclose;
    [SerializeField]
    private float coolDown = 1;
    private float coolDownTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Need some script of the main character to know things such as location, defenceMode. 
        player_script = playerObject.GetComponent<Player>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        player_defence = player_script.GetComponent<Defence>();
    }

    // Update is called once per frame
    public void Update()
    {
        // When MainCaracter dies, the game should stop (or not, depend on designer decision). This is only safe code just in case.  
        if (player_transform != null)
        {
            dist = Vector2.Distance(player_transform.position, transform.position);
            if (dist < howclose && !player_defence.defenseActivated())
            {
                if (coolDownTimer == 0f)
                {
                    Debug.Log("Saque vida");
                    player_script.TakeDamage(5);
                    
                    coolDownTimer = coolDown;
                }    
            }

            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }


        }

    }
}

