using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaGenerator : MonoBehaviour
{

    public GameObject grandMaPrefab;
    public Vector3 spawnPosition;

    public float spawnRate; //nb per second

    private float lastSpawnTime;

    void Start() {
        lastSpawnTime = 0;
    }

    void Update() {

        if (Time.time > lastSpawnTime + (1f / spawnRate)) {
            Instantiate<GameObject>(grandMaPrefab, spawnPosition, Quaternion.identity, transform);
            lastSpawnTime = Time.time;
        }
    }
}
