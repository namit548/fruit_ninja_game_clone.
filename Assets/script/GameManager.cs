using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [Header("VideoMemes")]//
    public VideoPlayer videoPlayer;//
    public string  lowScoreMemesFolder = "Memes videos/LowScore";//
    public string AveragecoreMemesFolder = "Memes videos/AverageScore";//
    public string highScoreMemesFolder = "Memes videos/HighScore";//

    private List<VideoClip> lowScoreMemes = new List<VideoClip>();//
    private List<VideoClip> AveragecoreMemes = new List<VideoClip>();//
    private List<VideoClip> highScoreMemes = new List<VideoClip>();//



    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;


    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighScoreText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        GetHighscore();
        LoadMemes();//
    }

    private void GetHighscore()
    {

        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }

    }

    public void OnBombHit()
    {
        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highscore.ToString();
        gameOverPanel.SetActive(true);

        PlayRandomMemes();//
        Debug.Log("Bomb hit");
    }

    public void RestartGame()
    {

        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
    private void LoadMemes()
    {
        lowScoreMemes.AddRange(Resources.LoadAll<VideoClip>(lowScoreMemesFolder));
        AveragecoreMemes.AddRange(Resources.LoadAll<VideoClip>(AveragecoreMemesFolder));
        highScoreMemes.AddRange(Resources.LoadAll<VideoClip>(highScoreMemesFolder));

        Debug.Log("Loaded {lowScoreMemes.Count} low score memes.");
        Debug.Log("Loaded {AveragecoreMemes.Count} mid score memes.");
        Debug.Log("Loaded {highScoreMemes.Count} high score memes.");

    }
    private void PlayRandomMemes()
    {
        if (videoPlayer == null) return;

        VideoClip clip = null;

        // Select a random meme based on the score
        if (score < 50 && lowScoreMemes.Count > 0)
        {
            clip = lowScoreMemes[Random.Range(0, lowScoreMemes.Count)];
        }
        else if (score >= 50 && score <= 150 && AveragecoreMemes.Count > 0)
        {
            clip = AveragecoreMemes[Random.Range(0, AveragecoreMemes.Count)];
        }
        else if (score > 150 && highScoreMemes.Count > 0)
        {
            clip = highScoreMemes[Random.Range(0, highScoreMemes.Count)];
        }

        if (clip != null)
        {
            videoPlayer.clip = clip;
            videoPlayer.Play();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0); // Reset high score
        highscore = 0;
        highscoreText.text = "Best: " + highscore.ToString();
        Debug.Log("High score reset to 0.");
    }


}
