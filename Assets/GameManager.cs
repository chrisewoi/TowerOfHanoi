using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform winningTower;
    public GameObject winningObj;
    public TMP_Text winningText;
    public TMP_Text turnText;
    public ScoreTracker scoreTracker;
    public int prevScore;

    public bool win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win = false;
        if (scoreTracker.score != 0) scoreTracker.scoreGot = true;
        prevScore = scoreTracker.score;
    }

    public void CheckGameOver()
    {
        if (winningTower.childCount >= 5)
        {
            win = true;
        }
        if(win)
        {
            winningObj.SetActive(true);
            if (scoreTracker.scoreGot)
            {
                int myScore = int.Parse(turnText.text);
                if (myScore < scoreTracker.score) // previous score recorded and have just beat it
                {
                    scoreTracker.score = int.Parse(turnText.text);
                    winningText.text = "Beat your high score!  \nNew high score: " + turnText.text + "\nPrevious high score: " + prevScore;
                }
                else // previous score recorded and didn't beat it
                {
                    winningText.text = "Completed in " + turnText.text + " turns. \nYour best completion: " + prevScore + ".";
                }
            }
            else // no previous score recorded
            {
                winningText.text = "Completed in " + turnText.text + " turns. First complete! Try beat your score! Least possible turns is 31!";
            }
            
        }
    }
}
