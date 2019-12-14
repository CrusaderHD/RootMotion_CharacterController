using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int xPosition;
    public int zPosition;
    public int enemyCount;
    public int enemyMaxCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    //Spawn enemy at random locations on the map over the course of time.
    IEnumerator SpawnEnemy()
    {
        while (enemyCount < enemyMaxCount)
        {
            xPosition = Random.Range(-50, 50);
            zPosition = Random.Range(-12, 33);
            Instantiate(enemy, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCount += 1;
        }
    }

}
