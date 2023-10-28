using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public string menuName = "Menu";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Fire2")){
            SceneManager.LoadScene(menuName);
        }
    }
}
