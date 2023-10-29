using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string playSceneLoadName = "Main";
    public EventSystem eventSystem;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();
        }
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayGame(){
        SceneManager.LoadScene(playSceneLoadName);
    }

}
