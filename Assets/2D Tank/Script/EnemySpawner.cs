using UnityEngine;


public class EnemySpawner : MonoBehaviour {
public GameObject enemyPrefab;
public float interval = 2f;
public int level = 1;
float timer;


void Update(){
timer += Time.deltaTime;
if(timer >= interval){
timer = 0f;
Vector3 pos = new Vector3(Random.Range(-8f,8f), Random.Range(-4f,4f), 0f);
Instantiate(enemyPrefab, pos, Quaternion.identity);
}
}
}