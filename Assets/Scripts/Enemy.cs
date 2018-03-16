using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class Enemy : MonoBehaviour
{
    
    private SpriteRenderer spriteR;

    public EnemyInfo enemyInfo;

    float stateChanceLeft, stateChanceRight, stateChanceHigh, stateChanceBlock;

    StateMachine<enemystates> fsm;

    
    public float health;

    public string currentState;

    public bool left, high, right;

    // Use this for initialization
    void Start()
    {


        spriteR = GetComponent<SpriteRenderer>();

        fsm = StateMachine<enemystates>.Initialize(this, enemystates.cooldown);
        //health = enemyInfo.Health;
        

        
    }

    public void InitEnemy()
    {
        spriteR = GetComponent<SpriteRenderer>();
        fsm = StateMachine<enemystates>.Initialize(this, enemystates.cooldown);
        health = enemyInfo.Health;
        EventManager.E_PlayerTap += TakeHit;
        if (this == null)
        {
            Instantiate(this);
        }
    }


    public void TakeHit(GameObject player, PlayerEventArgs args)
    {
        args.player.currentState = BLOCKSTATES.NOBLOCK;
        if (currentState != "block")
        {
            TakeDamage((args.player.GetCombo() / 10) + 1);
            args.player.ComboAdd();
            
        }
        else
        {
            args.player.ResetCombo();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            EventManager.E_PlayerTap -= TakeHit;
            GameManager.instance.LoadScene("wintest");
            GameManager.instance.DestroyLevel();
        }
    }

    #region idlestate
    void idle_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[0];
    }

    void idle_Update()
    {
        stateChanceLeft = Random.Range(0, enemyInfo.AttackLeftChance);
        stateChanceBlock = Random.Range(0, enemyInfo.BlockChance);
        stateChanceHigh = Random.Range(0, enemyInfo.AttackHighChance);
        stateChanceRight = Random.Range(0, enemyInfo.AttackRightChance);

        

        if (stateChanceRight >= stateChanceBlock && stateChanceRight >= stateChanceLeft && stateChanceRight >= stateChanceHigh)
        {
            right = true;
            fsm.ChangeState(enemystates.telegraphright, StateTransition.Safe);

        }
        else if (stateChanceLeft >= stateChanceBlock && stateChanceLeft >= stateChanceRight && stateChanceLeft >= stateChanceHigh)
        {
            left = true;
            fsm.ChangeState(enemystates.telegraphleft, StateTransition.Safe);

        }
        else if (stateChanceHigh >= stateChanceBlock && stateChanceHigh >= stateChanceRight && stateChanceHigh >= stateChanceLeft)
        {
            high = true;
            fsm.ChangeState(enemystates.telegraphhigh, StateTransition.Safe);

        }
        else if (stateChanceBlock >= stateChanceLeft && stateChanceBlock >= stateChanceRight && stateChanceBlock >= stateChanceHigh)
        {

            fsm.ChangeState(enemystates.telegraphblock, StateTransition.Safe);

        }

    }

    void idle_Exit()
    {

    }
    #endregion

    #region telegraphleft
    IEnumerator telegraphleft_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[2];
        yield return new WaitForSeconds(3);
        fsm.ChangeState(enemystates.attackleft, StateTransition.Safe);
    }

    void telegraphleft_Update()
    {
        //insert block check code
    }

    void telegraphleft_Exit()
    {

    }
    #endregion

    #region telegraphhigh
    IEnumerator telegraphhigh_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[6];
        yield return new WaitForSeconds(3);
        fsm.ChangeState(enemystates.attackhigh, StateTransition.Safe);
    }

    void telegraphhigh_Update()
    {

    }

    void telegraphhigh_Exit()
    {

    }
    #endregion

    #region telegraphright
    IEnumerator telegraphright_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[4];
        yield return new WaitForSeconds(3);
        fsm.ChangeState(enemystates.attackright, StateTransition.Safe);
    }

    void telegraphright_Update()
    {

    }

    void telegraphright_Exit()
    {

    }
    #endregion

    #region telegraphblock
    IEnumerator telegraphblock_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[8];
        yield return new WaitForSeconds(3);
        fsm.ChangeState(enemystates.block, StateTransition.Safe);
    }

    void telegraphblock_Update()
    {

    }

    void telegraphblock_Exit()
    {

    }
    #endregion

    #region attackleft
    IEnumerator attackleft_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[3];
        // if not blocked
        if (left)
        {
            EventManager.EnemyAttacking(this.gameObject, new EnemyEventArgs(this, "left"));
            left = false;
        }
        yield return new WaitForSeconds(1);
        fsm.ChangeState(enemystates.cooldown, StateTransition.Safe);
    }

    void attackleft_Update()
    {

    }

    void attackleft_Exit()
    {
        
    }
    #endregion

    #region attackhigh
    IEnumerator attackhigh_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[7];
        // if not blocked
        if (high)
        {
            EventManager.EnemyAttacking(this.gameObject, new EnemyEventArgs(this, "high"));
            high = false;
        }
        yield return new WaitForSeconds(1);
        fsm.ChangeState(enemystates.cooldown, StateTransition.Safe);
    }

    void attackhigh_Update()
    {

    }

    void attackhigh_Exit()
    {
        
    }
    #endregion

    #region attackright
    IEnumerator attackright_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[5];
        // if not blocked
        if (right)
        {
            EventManager.EnemyAttacking(this.gameObject, new EnemyEventArgs(this, "right"));
            right = false;
        }
        yield return new WaitForSeconds(1);
        fsm.ChangeState(enemystates.cooldown, StateTransition.Safe);
    }

    void attackright_Update()
    {

    }

    void attackright_Exit()
    {
        
    }
    #endregion

    #region block
    IEnumerator block_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[9];
        yield return new WaitForSeconds(2);
        fsm.ChangeState(enemystates.cooldown, StateTransition.Safe);
    }

    void block_Update()
    {

    }

    void block_Exit()
    {

    }
    #endregion

    #region cooldown
    IEnumerator cooldown_Enter()
    {
        spriteR.sprite = enemyInfo.EnemySprites[0];
        yield return new WaitForSeconds(3);
        fsm.ChangeState(enemystates.idle, StateTransition.Safe);
    }

    void cooldown_Update()
    {

    }

    void cooldown_Exit()
    {

    }
    #endregion

}
