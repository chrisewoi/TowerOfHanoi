using UnityEngine;

[CreateAssetMenu(fileName = "ScoreTracker", menuName = "ScoreTracker")]
public class ScoreTracker : ScriptableObject
{
    public int score;
    public bool scoreGot;
}
