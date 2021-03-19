using UnityEngine;
public class Enemy : Entity
{
    barColour bar;
    EnemyAttack enemy_attack;
    

    void Start()
    {
        bar = this.GetComponent<barColour>();
        // enemy_attack.FindEnemy();
        
    }

    void Update()
    {
        //enemy_attack.TryAttackPlayer();
        base.EntityUpdate();
        bar.colourBarCheck();
    }

}



