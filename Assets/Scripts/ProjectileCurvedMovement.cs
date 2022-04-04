using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCurvedMovement : MonoBehaviour
{
    public ProjectileSO projectileSO;
    public Vector2 target;

    private Vector2 initPoint;
    void Start() {
        initPoint = transform.position;
    }

    void Update() {

    }
}
