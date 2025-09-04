using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolGrille", menuName = "Scriptable Objects/PoolGrille")]
public class PoolGrille : ScriptableObject
{
    public List<PoolElement> poolElements;

    public Grille GetGrille(int currentLevel, List<PoolElement> listPoolElements)
    {
        foreach (PoolElement item in listPoolElements)
        {
            if (currentLevel <= item.maxLevel)
            {
                Grille grille;
                if (item.isRandom)
                {
                    Debug.Log("random");
                    grille = item.grilles[UnityEngine.Random.Range(0, item.grilles.Count)];
                }
                else
                {
                    Debug.Log("not random");
                    grille = item.grilles[Mathf.Min(item.grilles.Count -1, currentLevel)];
                }
                //int rd = UnityEngine.Random.Range(0, item.grilles.Count - 1);
                item.grilles.Remove(grille);
                return grille;
            }
        }
        return null;
    }
}

[Serializable]
public struct PoolElement
{
    public bool isRandom;
    public int maxLevel;
    public List<Grille> grilles;
}