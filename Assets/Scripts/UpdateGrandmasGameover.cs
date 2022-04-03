using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateGrandmasGameover : MonoBehaviour
{
    public ScoreSO scoreSO;
    private void OnEnable() {
        GetComponent<TMP_Text>().text = "You repelled " + scoreSO.nbGrandmasRepelled + " grandma" + (scoreSO.nbGrandmasRepelled > 1 ? "s" : "");
    }
}
