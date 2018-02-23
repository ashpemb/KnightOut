using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager> {

    public delegate void PlayerAttack(GameObject sender, PlayerEventArgs args);

    public static event PlayerAttack E_PlayerTap;

    public static void PlayerTap(GameObject sender, PlayerEventArgs args)
    {
        if (E_PlayerTap != null)
        {
            E_PlayerTap(sender, args);
        }
    }

    public delegate void EnemyAttack(GameObject sender, EnemyEventArgs args);

    public static event EnemyAttack E_EnemyAttack;

    public static void EnemyAttacking(GameObject sender, EnemyEventArgs args)
    {
        if (E_EnemyAttack != null)
        {
            E_EnemyAttack(sender, args);
        }
    }
}

public class EventArgs
{
    public static readonly EventArgs Empty;

    public EventArgs() { }
}

public class PlayerEventArgs
{
    public Player player;

    public PlayerEventArgs(Player player)
    {
        this.player = player;
    }
}

public class EnemyEventArgs
{
    public Enemy enemy;
    public string attack;

    public EnemyEventArgs(Enemy enemy, string attack)
    {
        this.enemy = enemy;
        this.attack = attack;
    }
}