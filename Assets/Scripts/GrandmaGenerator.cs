using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaGenerator : MonoBehaviour
{

    public GameObject grandMaPrefab;
    public Vector3 spawnPosition;

    public float spawnRate; //nb per second

    private float lastSpawnTime;
    private List<GameObject> instantiatedGrandmas;

    void Start() {
        instantiatedGrandmas = new List<GameObject>();
        Init();
    }

    public void Init() {
        foreach (GameObject grandma in instantiatedGrandmas) {
            Destroy(grandma);
        }
        instantiatedGrandmas.Clear();
        lastSpawnTime = 0;
    }

    void Update() {

        if (Time.time > lastSpawnTime + (1f / spawnRate)) {
            GameObject clone = Instantiate<GameObject>(grandMaPrefab, spawnPosition, Quaternion.identity, transform);
            instantiatedGrandmas.Add(clone);
            lastSpawnTime = Time.time;
        }
    }
}
