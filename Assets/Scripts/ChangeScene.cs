﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour{


    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadLevel(EnemyInfo enemyInfo)
    {
        GameManager.instance.LoadLevel(enemyInfo);
    }
}
