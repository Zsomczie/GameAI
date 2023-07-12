using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int PlayerScore=0;
    public int ComputerScore=0;
     [SerializeField]TMP_Text PlayerText;
     [SerializeField]TMP_Text ComputerText;
    // Update is called once per frame
    void Update()
    {
        PlayerText.text = PlayerScore.ToString();
        ComputerText.text = ComputerScore.ToString();
    }
}
