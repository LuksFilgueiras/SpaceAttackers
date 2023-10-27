using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string playSceneLoadName = "Main";
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
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
