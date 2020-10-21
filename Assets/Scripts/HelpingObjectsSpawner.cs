using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingObjectsSpawner : MonoBehaviour
{
    [SerializeField] private float timeOfSpawn = 8f;
    [SerializeField] private List<HelpingObjects> HelpingObjects = null;

    private float timeAfterLastSpawn = 0f;

    private void Start() 
    {
        StartCoroutine(SpawnHelpingObjects());
    }

    private IEnumerator SpawnHelpingObjects()
    {
        while(true)
        {
            float xRandomPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float zRandomPosition = Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2);
            int sumOfSpawn = 0;
            int border = 0;
            for (int i = 0; i < HelpingObjects.Count; i++)
            {
                sumOfSpawn += HelpingObjects[i].GetChance();
            }
            int random = Random.Range(0, sumOfSpawn);
            for (int i = 0; i < HelpingObjects.Count; i++)
            {
                if (HelpingObjects[i].GetChance() >= border && 
                    HelpingObjects[i].GetChance() <= random)
                {
                    Instantiate(HelpingObjects[i].GetGameObject(), new Vector3(transform.position.x + xRandomPosition,
                    transform.position.y + 0.25f, transform.position.z + zRandomPosition),
                    transform.rotation);
                    break;
                }
                else 
                {
                    border = HelpingObjects[i].GetChance();
                }
            }
            yield return new WaitForSeconds(timeOfSpawn);
        }
    }
}
