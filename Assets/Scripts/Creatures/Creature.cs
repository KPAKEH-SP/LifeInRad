using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour
{
    public int AttackPower;
    public Animator Anim;
    public Slider HealthBar;

    public void ChangeHealth(int count)
    {
        HealthBar.value += count;

        if (HealthBar.value == 0)
        {
            Death();
        }
    }

    public void Attack(Creature creatureScript)
    {
        creatureScript.ChangeHealth(-AttackPower);
    }

    public abstract void Death();
}
