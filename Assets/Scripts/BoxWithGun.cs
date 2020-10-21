using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithGun : MonoBehaviour, ISpawnable
{
    [SerializeField] private int chanceToSpawn = 10;

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
            other.GetComponent<Shooting>().GetNewGun();
            Destroy(gameObject);
        }
    }
}
