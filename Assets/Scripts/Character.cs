using System;
using UnityEngine;

public class Character :MonoBehaviour, IComparable<Character>
{
    private float speed;
    private string nameCharacter;

    public float Speed => speed;
    public string NameCharacter => nameCharacter;

    public Character(string nameCharacter, float speed)
    {
        this.speed = speed;
        this.nameCharacter = nameCharacter;
    }
    public int CompareTo(Character otherCharacter)
    {
        if (otherCharacter == null) return 1;

        return speed.CompareTo(otherCharacter.speed);
    }
}
