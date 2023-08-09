using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Behaviour : MonoBehaviour
{
    private Vector3 direction = new Vector3(0,1,0);
    private float speed = 5;
    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
