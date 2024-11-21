using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objsToSpawn;
    public GameObject Bomb;
    public Transform[] spawnPlaces;

    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;
    void Start()

    {
        StartCoroutine(SpawnFruits());

    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));// yield is used for pause and resume the executuion of coroutine
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float p = Random.Range(0, 100);

            if (p < 50) {
                go = Bomb;
            } else {
                go = objsToSpawn[Random.Range(0, objsToSpawn.Length)];
            }

            GameObject fruit = Instantiate(go,t.position,t.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Debug.Log("Fruit get spawned");
           Destroy(fruit, 5);
        }
            
    }

}


