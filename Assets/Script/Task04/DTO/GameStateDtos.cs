using System;

[Serializable]
public class UpsertStateDto
{
    public int level;
    public int score;
}

[Serializable]
public class StateDto
{
    public int playerId;
    public int level;
    public int score;
    public string updatedAt;
}
