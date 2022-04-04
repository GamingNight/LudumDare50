using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaGenerator : MonoBehaviour
{

    public GameObject grandMaPrefab;
    public Vector3 spawnPosition;
    public float spawnRate; //nb per second
    public ScoreSO scoreSo;
    public string sortingLayer;

    private float lastSpawnTime;
    private List<GameObject> instantiatedGrandmas;

    void Start() {
        Init();
    }

    public void Init() {
        if (instantiatedGrandmas == null)
            instantiatedGrandmas = new List<GameObject>();
        foreach (GameObject grandma in instantiatedGrandmas) {
            Destroy(grandma);
        }
        instantiatedGrandmas.Clear();
        lastSpawnTime = Time.time - (spawnRate == 0 ? 0 : 1f / spawnRate);
    }

    void Update() {

        if (spawnRate > 0) {
            if (Time.time > lastSpawnTime + (1f / spawnRate)) {
                GameObject clone = Instantiate<GameObject>(grandMaPrefab, spawnPosition, Quaternion.identity, transform);
                SpriteRenderer[] spriteRenderers = clone.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in spriteRenderers) {
                    sr.sortingLayerName = sortingLayer;
                }
                instantiatedGrandmas.Add(clone);
                lastSpawnTime = Time.time;
            }
        }
    }

    public void ResetSpawnRateTo(float value) {
        spawnRate = value;
        lastSpawnTime = Time.time - (spawnRate == 0 ? 0 : 1f / spawnRate);
    }
}
