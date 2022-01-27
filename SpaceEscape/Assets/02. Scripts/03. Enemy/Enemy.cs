using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int power;
    public int level;
    public int hp; public int maxHp;

    public Enemy(int level)
    {
        this.level = level;
        power = level * 3;
        maxHp = level * 15;
        hp = maxHp;
    }

}
