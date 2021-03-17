
using UnityEngine;

public class Enemy : Entity
{
    barColour bar;
    EnemyAttack enemy_attack;
    float lerpSpeed;

    void Start()
    {
        bar = this.GetComponent<barColour>();
        // enemy_attack.FindEnemy();
        lerpSpeed = 3f * Time.deltaTime;
    }

    void Update()
    {
        //enemy_attack.TryAttackPlayer();
        base.EntityUpdate();
        bar.colourBarCheck();
    }

}



