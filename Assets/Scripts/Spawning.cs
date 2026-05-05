using UnityEngine;
using System.Collections.Generic;

public class Spawning : MonoBehaviour
{
    public List<GameObject> SpawnPoints;

    public float timer = 0;
    public float spawnRate = 5;

    public GameObject rat;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 )
        {
            timer = spawnRate;
            Spawn();
        }
    }

    public void Spawn()
    {
        int randomI = Random.Range(0, SpawnPoints.Count);
        GameObject selectedPoint = SpawnPoints[randomI];
        Instantiate(rat, selectedPoint.transform.position, Quaternion.identity);
    }
}
