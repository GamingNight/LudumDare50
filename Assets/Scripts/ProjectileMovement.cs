using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public ProjectileSO projectileSO;
    public Vector2 direction;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = projectileSO.sprite;
    }

    void Update() {

        transform.Translate(direction * projectileSO.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Grandma") {
            Destroy(collision.gameObject);
        }
    }
}
