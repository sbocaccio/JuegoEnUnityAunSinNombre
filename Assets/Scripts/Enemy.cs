

using UnityEngine;

public class Enemy : Entity
{
    public int hola = 1;
    EnemyAttack enemy_attack; 
    void Start()
    {
       // enemy_attack.FindEnemy();
    }

    void Update()
    {
        //enemy_attack.TryAttackPlayer();
        base.EntityUpdate();
    }
   
}

