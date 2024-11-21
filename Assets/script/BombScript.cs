using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
    Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }
        FindObjectOfType<GameManager>().OnBombHit();
    }
}
