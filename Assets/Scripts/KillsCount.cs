using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsCount : MonoBehaviour
{
    public delegate void KillsCounter();

    public event KillsCounter killsCounter;

    public int killsCount = 0;
    private Text text;

    private void Start() 
    {
        text = GetComponent<Text>();
        Health.playerKill += UpdateKillsCount;
    }

    public void UpdateKillsCount()
    {
        killsCount++;
        text.text = "Kills: " + killsCount;
    }
}
