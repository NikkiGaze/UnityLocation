using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private SceneAsset gameScene;
    [SerializeField] private Text bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        bestScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
    
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(gameScene.name);
    }

}
