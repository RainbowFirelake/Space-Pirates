using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private List<EnemiesScriptableObject> enemiesToSpawn;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] Vector3 directionOfMoving = Vector3.forward;

    private float timeAfterLastSpawn = Mathf.Infinity;

    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update() 
    {
        timeAfterLastSpawn += Time.deltaTime;    
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int chancesToSpawn = 0;
            for (int i = 0; i < enemiesToSpawn.Count; i++)
            {
                chancesToSpawn += enemiesToSpawn[i].GetChanceToSpawn();
            }
            Debug.Log("Chances to spawn: " + chancesToSpawn);
            int randomSpawn = Random.Range(0, chancesToSpawn + 1);
            int border = 0;
            Debug.Log("random spawn: " + randomSpawn);
            for (int i = 0; i < enemiesToSpawn.Count; i++)
            {
                if (randomSpawn >= border && randomSpawn <= enemiesToSpawn[i].GetChanceToSpawn())
                {
                    float xRandomPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                    Instantiate(enemiesToSpawn[i].GetEnemyPrefab(), new Vector3(xRandomPosition, transform.position.y,
                        transform.position.z), transform.rotation).GetComponent<EnemyAI>().SetDirectionOfMoving(directionOfMoving);
                    timeAfterLastSpawn = 0f;
                    break;
                }
                else 
                {
                    border = enemiesToSpawn[i].GetChanceToSpawn();
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }   
    }
}
