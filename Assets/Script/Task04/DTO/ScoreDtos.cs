using System;

[Serializable]
public class SubmitScoreDto
{
    public int playerId;
    public int score;
}

[Serializable]
public class ScoreDto
{
    public int id;
    public int playerId;
    public int score;
    public string createdAt;
}
