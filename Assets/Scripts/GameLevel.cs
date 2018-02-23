using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel {

    [HideInInspector]
    public GameObject enemyObj;
    [HideInInspector]
    public GameObject playerObj;
    [HideInInspector]
    public GameObject playerHealthBar;
    [HideInInspector]
    public GameObject enemyHealthBar;
    [HideInInspector]
    public Text comboCount;
    

    Slider enemyHealthSlider;
    Slider playerHealthSlider;
    Player player;
    Enemy enemy;
    EnemyInfo levelInfo;
    SpriteRenderer backGround;

    public bool levelLoaded = false;
    public int LevelNum = 0;

    private Vector2 playerPos = new Vector2(-0.5f, -3.5f);
    private Vector2 enemyPos = new Vector2(1.5f, 0.5f);
    int combo = 0;

    public GameLevel(EnemyInfo enemyInfo)
    {
        levelInfo = enemyInfo;
    }

    public void initLevel()
    {
        levelLoaded = true;
        backGround = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        enemyObj = GameObject.FindGameObjectWithTag("Enemy");
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealth");
        enemyHealthBar = GameObject.FindGameObjectWithTag("EnemyHealth");
        comboCount = GameObject.FindGameObjectWithTag("Combo").GetComponent<Text>();
        playerHealthSlider = playerHealthBar.GetComponentInChildren<Slider>();
        enemyHealthSlider = enemyHealthBar.GetComponentInChildren<Slider>();
        enemy = enemyObj.GetComponent<Enemy>();
        enemy.enemyInfo = levelInfo;
        backGround.sprite = levelInfo.BackgroundSprite;
        player = playerObj.GetComponent<Player>();
        playerHealthSlider.value = player.health;
        enemyHealthSlider.value = enemy.health;
        playerHealthSlider.maxValue = player.maxHealth;
        enemyHealthSlider.maxValue = levelInfo.Health;
        player.InitPlayer();
        enemy.InitEnemy();
    }

    public void Update()
    {
        playerHealthSlider.value = player.health;
        enemyHealthSlider.value = enemy.health;

        combo = player.GetCombo();

        comboCount.text = "X" + combo;
    }


}
