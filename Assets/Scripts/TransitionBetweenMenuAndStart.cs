using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenMenuAndStart : MonoBehaviour
{
    public AudioSource ringSource;
    private bool launched;

    private void Start() {
        launched = false;
    }

    public void Go() {
        launched = true;
        ringSource.Play();
    }

    void Update() {
        if (launched && !ringSource.isPlaying) {
            launched = false;
            GameManager.GetInstance().StartGame();
        }
    }
}
