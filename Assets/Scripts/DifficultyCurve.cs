using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyCurve : MonoBehaviour
{
    public ScoreSO score;
    public SetDifficulty setDifficultyScript;
    public AudioSource[] musicLayersEasy;
    public AudioSource[] musicLayersMedium;
    public AudioSource[] musicLayersHard;
    public AudioSource[] musicLayersSuperHard;


    void Update() {
        if (score.nbGrandmasRepelled > 15 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.SUPER_EASY) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.EASY;
            foreach (AudioSource src in musicLayersEasy) {
                src.volume = 0.3f;
            }
        } else if (score.nbGrandmasRepelled > 35 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.EASY) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.MEDIUM;
            foreach (AudioSource src in musicLayersMedium) {
                src.volume = 0.3f;
            }
        } else if (score.nbGrandmasRepelled > 50 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.MEDIUM) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.HARD;
            foreach (AudioSource src in musicLayersHard) {
                src.volume = 0.3f;
            }
        } else if (score.nbGrandmasRepelled > 80 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.HARD) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.SUPER_HARD;
            foreach (AudioSource src in musicLayersSuperHard) {
                src.volume = 0.3f;
            }
        }
    }
}
