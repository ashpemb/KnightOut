using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int health;
    public BLOCKSTATES currentState = 0;
    int comboNum = 0;

    // Use this for initialization
    void Start () {
        //health = maxHealth;
        
	}
	
	public void InitPlayer()
    {
        health = maxHealth;
        EventManager.E_EnemyAttack += PlayerTakeHit;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        currentState = BLOCKSTATES.NOBLOCK;
        if (health <= 0)
        {
            EventManager.E_EnemyAttack -= PlayerTakeHit;
            GameManager.instance.LoadScene("gameovertest");
            GameManager.instance.DestroyLevel();
        }
    }

    public void ComboAdd()
    {
        comboNum++;
    }
    public int GetCombo()
    {
        return comboNum;
    }

    public void ResetCombo()
    {
        comboNum = 0;
    }

    public void PlayerTakeHit(GameObject sender, EnemyEventArgs args)
    {
        if (currentState == BLOCKSTATES.BLOCKLEFT && args.enemy.left == true)
        {
            args.enemy.left = false;
            ComboAdd();
            currentState = BLOCKSTATES.NOBLOCK;
        }
        else if (currentState == BLOCKSTATES.BLOCKRIGHT && args.enemy.right == true)
        {
            args.enemy.right = false;
            ComboAdd();
            currentState = BLOCKSTATES.NOBLOCK;
        }
        else if (currentState == BLOCKSTATES.BLOCKHIGH && args.enemy.high == true)
        {
            args.enemy.high = false;
            ComboAdd();
            currentState = BLOCKSTATES.NOBLOCK;
        }
        else
        {
            TakeDamage(args.enemy.enemyInfo.AttackValue);
            ResetCombo();
            currentState = BLOCKSTATES.NOBLOCK;
        }
    }
}
