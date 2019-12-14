using UnityEngine;
using System.Collections.Generic;

public class PowerupManager : MonoBehaviour
{

    public List<Transform> powerUpSpawnLocations;
    public GameObject powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(powerUpPrefabs, powerUpSpawnLocations.position, Quaternion.identity);
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            Vector3 position = powerUpSpawnLocations[Random.Range(0, powerUpSpawnLocations.Count)].position;
            powerUpPrefabs = Instantiate(powerUpPrefabs, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
