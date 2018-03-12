using System.Collections;
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

    public void LoadLevel()
    {
        GameManager.instance.LoadLevel(GameManager.instance.m_SelectedLevel);
    }

    public void LevelSelect(EnemyInfo enemyInfo)
    {
        GameManager.instance.m_SelectedLevel = enemyInfo;
        GameManager.instance.prepScreen.SetActive(true);
    }

    public void ClearSelection()
    {
        GameManager.instance.m_SelectedLevel = null;
        GameManager.instance.prepScreen.SetActive(false);
    }
}
