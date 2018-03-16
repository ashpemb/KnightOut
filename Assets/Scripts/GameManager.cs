using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager> {

    public GameLevel m_CurrentLevel;
    public EnemyInfo m_SelectedLevel;
    public GameObject prepScreen;

    private void Update()
    {
        if(m_CurrentLevel != null && m_CurrentLevel.levelLoaded == true)
        {
            m_CurrentLevel.Update();
        }
    }

    public void LoadLevel(EnemyInfo LevelEnemy)
    {
        StartCoroutine(LoadYourAsyncScene("test"));

        m_CurrentLevel = new GameLevel(LevelEnemy);
        
    }
    public void CreateLevel(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "test")
        {
            m_CurrentLevel.initLevel();
        }
        else if (scene.name == "LevelSelect")
        {
            prepScreen = GameObject.Find("Canvas-PrepScreen");
            prepScreen.SetActive(false);
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += CreateLevel;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= CreateLevel;
    }

    public void LoadScene(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    IEnumerator LoadYourAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
            
        }
    }

    public void DestroyLevel()
    {
        m_CurrentLevel.levelLoaded = false;
        m_CurrentLevel = null;
        m_SelectedLevel = null;
    }
}
