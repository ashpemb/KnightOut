using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemy", menuName = "Enemy/BasicEnemy", order = 1)]
public class EnemyInfo : ScriptableObject {

    public new string name;
    public int Health;
    public float AttackLeftChance, AttackRightChance, AttackHighChance,BlockChance;
    public int AttackValue;
    public int StaminaCost;
    public Sprite[] EnemySprites; //Must be in same order as test
    public Sprite BackgroundSprite;
    

}
