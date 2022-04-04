using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyCurve : MonoBehaviour
{
    public ScoreSO score;
    public SetDifficulty setDifficultyScript;

    void Update()
    {
        if(score.nbGrandmasRepelled > 15 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.SUPER_EASY) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.EASY;
        }else if(score.nbGrandmasRepelled > 35 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.EASY) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.MEDIUM;
        } else if (score.nbGrandmasRepelled > 50 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.MEDIUM) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.HARD;
        } else if (score.nbGrandmasRepelled > 80 && setDifficultyScript.difficulty == SetDifficulty.Difficulty.HARD) {
            setDifficultyScript.difficulty = SetDifficulty.Difficulty.SUPER_HARD;
        }
    }
}
