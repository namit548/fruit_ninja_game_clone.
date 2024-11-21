using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public GameObject slicedFruitPrefabs;
    //private void Update()
    //{
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            CreateSlicedFruit();
    //        }
    //    }
    //}
    public void CreateSlicedFruit()
    {
       GameObject inst = (GameObject) Instantiate(slicedFruitPrefabs, transform.position, transform.rotation);//New fruit will be spwan and with same rotation in prefabs,same position,from prefab
        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rbsOnSliced)// using rigidbody and destroy
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }
        FindObjectOfType<GameManager>().IncreaseScore(3);


        Destroy(gameObject);//destroy prefabs again
        Destroy(inst.gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;

        } 
        CreateSlicedFruit();
    }
  
}
