using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Step", menuName = "ScriptableObjects/Step", order = 1)]
public class StepSO : ScriptableObject
{
    public string Question;
    public List<Response> Responses;
    public Difficulty StepDifficulty;
}
[System.Serializable]
public class Response{
    public string responseString;
    public bool isCorrect;
}

public enum Difficulty{easy, medium, hard}
