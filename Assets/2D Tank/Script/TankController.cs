using UnityEngine;


public class TankController : MonoBehaviour {
public float moveSpeed = 4f;
public float rotateSpeed = 180f;
public Transform firePoint;
public GameObject bulletPrefab;
public int hp = 100;


void Update(){
float h = Input.GetAxisRaw("Horizontal");
float v = Input.GetAxisRaw("Vertical");


// Gerak maju/mundur
transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime);
// Rotasi kiri/kanan
transform.Rotate(Vector3.forward * -h * rotateSpeed * Time.deltaTime);


if(Input.GetKeyDown(KeyCode.Space)) Shoot();
}


void Shoot(){
if(bulletPrefab && firePoint){
Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
}
}
}