using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Path MovingPath;
    public System.Action killed;
    int HP = 5;
    float movingSpeed = 2.0f;
    private Transform targetPoint;

    private float waitTime = 5.0f;
    private float currentTime = 0.0f;
    private bool isWaiting = true;
    private bool invincible = true;

    public void SetPath(Path path)
    {
        MovingPath = path;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                HP--;
            }
            if (HP == 0)
            {
                this.killed?.Invoke();
                Destroy(this.gameObject);
            }
        }
    }

    public void Start()
    {
        if (MovingPath == null)
        {
            return;
        }
        targetPoint = MovingPath.getPointAt(0);
    }
    private void Update()
    {
        if (isWaiting)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= waitTime)
            {
                isWaiting = false;
            }
            else
            {
                return;
            }
        }
        else
        {
            if (MovingPath == null)
            {
                invincible = false;
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, movingSpeed * Time.deltaTime);

            var distanceTarget = (transform.position - targetPoint.position).sqrMagnitude;
            if (distanceTarget < 0.1f)
            {
                targetPoint = MovingPath.getNextPoint();
            }
            invincible = false;
        }
    }
}
