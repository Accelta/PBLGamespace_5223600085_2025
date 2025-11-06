using System;

// DTO untuk player, menyesuaikan dengan backend ASP.NET
[Serializable]
public class CreatePlayerDto
{
    public string name;
}

[Serializable]
public class PlayerDto
{
    public int id;
    public string name;
    public string createdAt;
}
