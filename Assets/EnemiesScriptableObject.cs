using UnityEngine;

[CreateAssetMenu(fileName = "Create Enemy", menuName = "Enemies/Create Enemy", order = 0)]
public class EnemiesScriptableObject : ScriptableObject 
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private int chanceToSpawn;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public int GetChanceToSpawn()
    {
        return chanceToSpawn;
    }
}
