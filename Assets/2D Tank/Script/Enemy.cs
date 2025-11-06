using UnityEngine;


public class Enemy : MonoBehaviour {
public int hp = 50;
public float speed = 2f;
Transform target;


void Start(){
target = GameObject.FindWithTag("Player")?.transform;
}


void Update(){
if(target){
Vector3 dir = (target.position - transform.position).normalized;
transform.position += dir * speed * Time.deltaTime;
}
}


public void TakeDamage(int d){
hp -= d;
if(hp <= 0) Destroy(gameObject);
}
}