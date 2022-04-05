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
    public GameObject gameAudioContainer;
    public AudioSourceContainerSO inGameAudioContainerSO;
    public GameObject gameoverMenu;
    public GameObject startMenu;

    void Start() {

    }

    void Update() {

    }

    public void GameOver() {
        inGameAudioContainerSO.Clear();
        game.SetActive(false);
        gameoverMenu.SetActive(true);
    }

    public void StartGame() {
        game.GetComponent<InitGame>().Init();
        startMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        game.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void StartMenu() {
        game.SetActive(false);
        gameoverMenu.SetActive(false);
        startMenu.SetActive(true);
    }
}
