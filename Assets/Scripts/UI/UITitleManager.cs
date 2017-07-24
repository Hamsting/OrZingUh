using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitleManager : MonoBehaviour {


    public void OnGameStart() {
        SceneManager.LoadScene("GameScene");
    }

    public void OnGameExit() {
        Application.Quit();
    }

}
