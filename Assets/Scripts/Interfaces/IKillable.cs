using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    int GetHealth();
    void TakeDamage(int damage);
    void Kill();
}
