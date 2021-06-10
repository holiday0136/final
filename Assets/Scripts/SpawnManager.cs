using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject speedPrefab;
    [SerializeField] public GameObject growPrefab;
    [SerializeField] public GameObject superjumpPrefab;
    [SerializeField] public Vector3 spawnpoint;
    public float time;
    public float randomtime;
    public int randomitem;

    // Start is called before the first frame update
    void Start()
    {
        randomtime = Random.Range(5, 20);
        randomitem = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= randomtime)
        {
            Spawn();
        }
        time += Time.deltaTime;
    }

    void Spawn()
    {

        if(randomitem == 1)
        {
            Instantiate(growPrefab, spawnpoint, Quaternion.identity);
        }

        if (randomitem == 2)
        {
            Instantiate(superjumpPrefab, spawnpoint, Quaternion.identity);
        }

        if (randomitem == 3)
        {
            Instantiate(speedPrefab, spawnpoint, Quaternion.identity);
        }

        time = 0;

        randomtime = Random.Range(40, 100);
    }
}
