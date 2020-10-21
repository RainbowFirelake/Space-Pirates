using UnityEngine;

[CreateAssetMenu(fileName = "HelpingObjects", menuName = "HelpingObjects/Create Helping Object", order = 0)]
public class HelpingObjects : ScriptableObject 
{
    [SerializeField] private GameObject HelpingObject;
    [SerializeField] private int ChanceToSpawn;

    public GameObject GetGameObject()
    {
        return HelpingObject;
    }

    public int GetChance()
    {
        return ChanceToSpawn;
    }
}
