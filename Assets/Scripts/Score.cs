using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text PanelScore;
    [SerializeField] Text _ScoreText;
    [SerializeField] Text HighScore;
    [SerializeField] GameObject NewHighScore;

    int _score;
    int _highScore;

    void Start()
    {
        _score = 0;
        _ScoreText.text = _score.ToString();
        PanelScore.text = _score.ToString();
        _highScore = PlayerPrefs.GetInt("highScore");
        HighScore.text = _highScore.ToString();
    }
    public void Scored()
    {
        _score++;
        _ScoreText.text = _score.ToString();
        PanelScore.text = _score.ToString();
        if(_score > _highScore)
        {
            _highScore = _score;
            HighScore.text = _highScore.ToString();
            PlayerPrefs.SetInt("highScore", _highScore);
            NewHighScore.SetActive(true);
        }
    }
    public int GetScore()
    {
        return _score;
    }
}
