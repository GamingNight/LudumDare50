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
    public AudioSource[] musicLayersEasy;
    public AudioSource[] musicLayersMedium;
    public AudioSource[] musicLayersHard;
    public AudioSource[] musicLayersSuperHard;

    private Difficulty previousDifficulty;

    private void Start() {
        SetDifficultyOnGenerators(0.25f);
    }

    void Update() {

        if (previousDifficulty != difficulty) {
            float spawnRate = 0;
            List<AudioSource> tracksToMute = new List<AudioSource>();
            List<AudioSource> tracksToPlay = new List<AudioSource>();
            switch (difficulty) {
                case Difficulty.SUPER_EASY:
                    tracksToMute.AddRange(musicLayersEasy);
                    tracksToMute.AddRange(musicLayersMedium);
                    tracksToMute.AddRange(musicLayersHard);
                    tracksToMute.AddRange(musicLayersSuperHard);
                    spawnRate = 0.25f;
                    break;
                case Difficulty.EASY:
                    tracksToPlay.AddRange(musicLayersEasy);
                    tracksToMute.AddRange(musicLayersMedium);
                    tracksToMute.AddRange(musicLayersHard);
                    tracksToMute.AddRange(musicLayersSuperHard);
                    spawnRate = 0.5f;
                    break;
                case Difficulty.MEDIUM:
                    tracksToPlay.AddRange(musicLayersEasy);
                    tracksToPlay.AddRange(musicLayersMedium);
                    tracksToMute.AddRange(musicLayersHard);
                    tracksToMute.AddRange(musicLayersSuperHard);
                    spawnRate = 1f;
                    break;
                case Difficulty.HARD:
                    tracksToPlay.AddRange(musicLayersEasy);
                    tracksToPlay.AddRange(musicLayersMedium);
                    tracksToPlay.AddRange(musicLayersHard);
                    tracksToMute.AddRange(musicLayersSuperHard);
                    spawnRate = 1.5f;
                    break;
                case Difficulty.SUPER_HARD:
                    tracksToPlay.AddRange(musicLayersEasy);
                    tracksToPlay.AddRange(musicLayersMedium);
                    tracksToPlay.AddRange(musicLayersHard);
                    tracksToPlay.AddRange(musicLayersSuperHard);
                    spawnRate = 2f;
                    break;
                default:
                    break;
            }
            SetDifficultyOnGenerators(spawnRate);
            foreach (AudioSource track in tracksToMute) {
                track.volume = 0f;
            }
            foreach (AudioSource track in tracksToPlay) {
                track.volume = 0.3f;
            }
            previousDifficulty = difficulty;
        }
    }
    private void SetDifficultyOnGenerators(float spawnRate) {
        foreach (GrandmaGenerator generator in generators) {
            generator.ResetSpawnRateTo(spawnRate);
        }
    }
}
