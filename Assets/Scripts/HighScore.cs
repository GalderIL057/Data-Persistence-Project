using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private void Start()
    {
        DataPlayer.instance.CalculateHighScore();
    }
}