using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject scoreTable;
    [SerializeField] private GameObject scoreCellPrefab;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        DownloadHighScore();
    }
    
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    private async void DownloadHighScore()
    {
        var scores = await DatabaseService.Instance().GetTopPlayers();
        ClearTable();
        foreach (var score in scores)
        {
            var cell = Instantiate(scoreCellPrefab, scoreTable.transform);
            cell.GetComponent<ScoreCell>().SetValues(score.Nickname, score.Score);
        }
    }

    private void ClearTable()
    {
        if (scoreTable != null)
            foreach (Transform child in scoreTable.transform) {
                Destroy(child.gameObject);
            }
    }

}
