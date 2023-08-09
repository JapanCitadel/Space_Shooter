using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    int rows = 4;
    int cols = 4;
    public EnemyBehaviour[] enemyPrefab = new EnemyBehaviour[16];
    public LogicScript logic;
    float moveSpeed = 1.0f;
    int stopPoint = 2;
    private Vector3 direction = Vector2.down;
    public GameObject path1Obj;
    public GameObject path2Obj;
    public GameObject path3Obj;
    public GameObject path4Obj;
    /*public GameObject path5Obj;
    public GameObject path6Obj;
    public GameObject path7Obj;
    public GameObject path8Obj;
    public GameObject path9Obj;
    public GameObject path10Obj;
    public GameObject path11Obj;
    public GameObject path12Obj;
    public GameObject path13Obj;
    public GameObject path14Obj;
    public GameObject path15Obj;
    public GameObject path16Obj;
    public GameObject path17Obj;
    public GameObject path18Obj;
    public GameObject path19Obj;*/

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 1.0f * (this.cols - 1);
            float height = 1.0f * (this.rows - 1);
            Vector3 center = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3(center.x, center.y + (row * 1.0f), 0.0f);
            for (int col = 0; col < this.cols; col++)
            {
                int i = row * cols + col;
                EnemyBehaviour enemies = Instantiate(this.enemyPrefab[i], this.transform);
                enemies.killed += EnemyKilled;
                enemies.Start();
                Vector3 pos = rowPos;
                pos.x += col * 1.0f;
                enemies.transform.localPosition = pos;
                switch (i)
                {
                    case 0:
                        enemies.SetPath(path1Obj.GetComponent<Path>());
                        break;
                    case 1:
                        enemies.SetPath(path2Obj.GetComponent<Path>());
                        break;
                    case 2:
                        enemies.SetPath(path3Obj.GetComponent<Path>());
                        break;
                    case 3:
                        enemies.SetPath(path4Obj.GetComponent<Path>());
                        break;
                    default:
                        enemies.SetPath(null);
                        break;
                }
            }
        }
    }

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }
    private void Update()
    {
        if (transform.position.y <= stopPoint)
        {
            this.transform.position = new Vector3(this.transform.position.x, stopPoint, this.transform.position.z);
        }
        else
        {
            this.transform.position += direction * this.moveSpeed * Time.deltaTime;
        }
    }
    
    private void EnemyKilled()
    {
        logic.addScore();
    }
}
