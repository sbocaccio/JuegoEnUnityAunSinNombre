using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class FoeAttack : MonoBehaviour
    {
        public float howclose;
        public float attackCoolDown;
        public GameObject player;
        Timer timer;
        bool attacking = false;

        // Start is called before the first frame update
        void Start()
        {
            timer = new Timer(attackCoolDown);
        }

        // Update is called once per frame
        public void Update()
        {


            // When MainCaracter dies, the game should stop (or not, depend on designer decision). This is only safe code just in case.  
            if (player.transform != null)
            {

                // Attack if in range
                float dist = Vector2.Distance(player.transform.position, transform.position);
                if (dist < howclose && (player.GetComponent<Defence>().defenseSize() < 0 && ((player.transform.position.x - transform.position.x < 0)) || //Attack from behind
                    (player.GetComponent<Defence>().defenseSize() > 0 && (player.transform.position.x - transform.position.x > 0))))
                {
                    attacking = true;
                  //  this.GetComponent<enemy_animator>().Attack();
                    player.GetComponent<Entity>().TakeDamage(5);
                    timer.setTimer();

                }
            }

        }
        public bool AttackStatus()
        {
            return attacking;
        } 
    }


}
