using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public KidSO kidSO;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = kidSO.sprite;
    }

    void Update() {

    }
}
