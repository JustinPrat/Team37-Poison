using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolGrille", menuName = "Scriptable Objects/PoolGrille")]
public class PoolGrille : ScriptableObject
{
    public List<PoolElement> poolElements;

    public Grille GetGrille(int currentLevel)
    {
        foreach (PoolElement item in poolElements)
        {
            if (currentLevel <= item.maxLevel)
            {
                return item.grilles[UnityEngine.Random.Range(0, item.grilles.Count - 1)];
            }
        }
        return null;
    }
}

[Serializable]
public struct PoolElement
{
    public int maxLevel;
    public List<Grille> grilles;
}