using Alchemy.Serialization;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public PoolGrille poolGrille;

    private int _intCurrentLevel;
    private Grille _currentGrille;

    public Transform _anchorGrille;

    private void Awake()
    {
        instanceGameManager = this;
    }

    private void Start()
    {
        _intCurrentLevel = 0;
        _currentGrille = Instantiate(poolGrille.GetGrille(_intCurrentLevel));
        _currentGrille.transform.position = _anchorGrille.position;
    }

    public void VerifPatternComplete()
    {
        if (_currentGrille.VerifGrille())
        {
            Debug.Log("c'est gagné");
            _intCurrentLevel++;
            Destroy(_currentGrille.gameObject);
            _currentGrille = Instantiate(poolGrille.GetGrille(_intCurrentLevel));
            _currentGrille.transform.position = _anchorGrille.position;
        }
    }
}
