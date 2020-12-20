

public class Enemy : Entity
{

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
