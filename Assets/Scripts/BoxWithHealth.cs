using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithHealth : MonoBehaviour, ISpawnable
{
    [SerializeField] private float healthToAdd = 15f;
    [SerializeField] private int chanceToSpawn = 50;

    public int GetChance()
    {
        return chanceToSpawn;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<Health>().AddHealth(healthToAdd);
            Destroy(gameObject);
        }    
    }
}
