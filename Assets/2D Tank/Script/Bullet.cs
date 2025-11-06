using UnityEngine;


public class Bullet : MonoBehaviour {
public float speed = 8f;
public int damage = 25;
public float lifetime = 3f;


void Start(){ Destroy(gameObject, lifetime); }
void Update(){ transform.Translate(Vector3.up * speed * Time.deltaTime); }


void OnTriggerEnter2D(Collider2D col){
var enemy = col.GetComponent<Enemy>();
if(enemy){ enemy.TakeDamage(damage); Destroy(gameObject); }
}
}