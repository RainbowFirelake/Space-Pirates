using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsCount : MonoBehaviour
{
    private Text shotsCount;

    private void Start() 
    {
        shotsCount = GetComponent<Text>();
        Shooting.shots += UpdateText;
    }

    public void UpdateText(int number)
    {
        shotsCount.text = "Shots: " + number;
    }
}
