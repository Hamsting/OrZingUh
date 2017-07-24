using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitleManager : MonoBehaviour {

    private void Start()
    {
        AudioManager.instance.PlayTitle();
    }

    public void OnGameStart() {
        AudioManager.instance.PlayTouch();
        SceneManager.LoadScene("GameScene");
    }

    public void OnGameExit() {
        AudioManager.instance.PlayTouch();
        Application.Quit();
    }

}
