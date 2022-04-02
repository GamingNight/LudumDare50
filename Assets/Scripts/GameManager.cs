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

    void Start() {

    }

    void Update() {

    }

    public void GameOver() {
        game.SetActive(false);
    }
}
