using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;
    public GameObject spawnPoint;

    // Update is called once per frame
    void Start()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = spawnPoint.transform.position;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
