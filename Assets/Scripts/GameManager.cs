using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager GetInstance() {
        return instance;
    }

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    public GameObject game;
    public GameObject gameover;

    void Start() {

    }

    void Update() {

    }

    public void GameOver() {
        game.SetActive(false);
        gameover.SetActive(true);
    }

    public void StartGame() {
        game.GetComponent<InitGame>().Init();
        gameover.SetActive(false);
        game.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}
