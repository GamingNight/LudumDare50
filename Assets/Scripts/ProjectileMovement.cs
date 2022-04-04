using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public ProjectileSO projectileSO;
    public Vector2 direction;

    void Update() {

        transform.position = new Vector2(transform.position.x, transform.position.y) + (direction * projectileSO.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Grandma") {
            Destroy(gameObject);
        }
    }
}
