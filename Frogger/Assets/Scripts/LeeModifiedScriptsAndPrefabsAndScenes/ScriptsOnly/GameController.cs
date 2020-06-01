using System.Linq;
//using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _score;
    private int _hiScore = 4630;
    private int _lives = 3;
    private bool _gameOver;
    private int _goalsOccupied;
    
    //Lee added
    //private float fixedDeltaTime;

    public VehicleSpawnPoint[] points;

    public Goal[] goals;

    public int Score { get { return _score; } }

    public int HiScore { get { return _hiScore; } }

    public int Lives { get { return _lives; } }
    
    public bool GameOver { get { return _gameOver; } }

    public void IncrementScore(int scoreValue)
    {
        _score += scoreValue;
        if (_score > _hiScore)
        {
            _hiScore = _score;
        }
    }

    public void DecrementLives()
    {
        _lives--;
        if (_lives <= 0)
        {
            if (!_gameOver)
            {
                foreach(var spawnPoint in points)
                {
                    spawnPoint.GameOver();
                }
            }
            AudioController.Instance.GameOverSequence();
            _gameOver = true;
            _lives = 0;
        }
    }

    void Awake()
    {
        // Lee added
        //this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale = 1;
        _score = PlayerPrefs.GetInt("score", 0);
    }

    void Update()
    {
        var newGoals = goals.Count(g => g.GoalOccupied);
        if (newGoals != _goalsOccupied)
        {
            if (newGoals == 5)
            {
                //Lee
                Time.timeScale = 0;
                
                AudioController.Instance.PlayEndOfRound(() =>
                {
                    ;
                    PlayerPrefs.SetInt("score", _score);
                    // removed following from here and added to AudioController 
                    //SceneManager.LoadScene("Game");
                });
            }
            else
            {
                AudioController.Instance.PlayHome();
            }
            _goalsOccupied = newGoals;
        }
    }
}
