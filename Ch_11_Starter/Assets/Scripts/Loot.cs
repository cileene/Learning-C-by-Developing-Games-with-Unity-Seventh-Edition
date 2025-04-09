using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
public struct Loot
{
// 2
    public string name;
    public int rarity;
// 3
    public Loot(string name, int rarity)
    {
        this.name = name;
        this.rarity = rarity;
    }
}