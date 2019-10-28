using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public Transform powerUpSpawnLocations;
    public GameObject powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpPrefabs, powerUpSpawnLocations.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
