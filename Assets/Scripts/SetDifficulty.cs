using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public enum Difficulty
    {
        SUPER_EASY, EASY, MEDIUM, HARD, SUPER_HARD
    }

    public Difficulty difficulty;
    public GrandmaGenerator[] generators;

    private Difficulty previousDifficulty;
    private bool first;

    private void Start() {
        first = true;
    }

    void Update() {

        if (first || previousDifficulty != difficulty) {
            float spawnRate = 0;
            switch (difficulty) {
                case Difficulty.SUPER_EASY:
                    spawnRate = 0.25f;
                    break;
                case Difficulty.EASY:
                    spawnRate = 0.5f;
                    break;
                case Difficulty.MEDIUM:
                    spawnRate = 1f;
                    break;
                case Difficulty.HARD:
                    spawnRate = 1.5f;
                    break;
                case Difficulty.SUPER_HARD:
                    spawnRate = 2f;
                    break;
                default:
                    break;
            }
            foreach (GrandmaGenerator generator in generators) {
                generator.ResetSpawnRateTo(spawnRate);
            }
            previousDifficulty = difficulty;
            first = false;
        }
    }
}
