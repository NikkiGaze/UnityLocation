using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCell : MonoBehaviour
{
    [SerializeField] private Text nicknameText;
    [SerializeField] private Text scoreText;
    
    // Start is called before the first frame update

    public void SetValues(string nickname, int score)
    {
        nicknameText.text = nickname;
        scoreText.text = score.ToString();
    }
}
