using Alchemy.Serialization;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public partial class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public PoolGrille poolGrille;

    private int _intCurrentLevel;
    private Grille _currentGrille;

    public Transform _anchorGrille;

    private List<PoolElement> copyPoolGrille = new List<PoolElement>();

    public Action OnWin;

    [SerializeField] float _timer = 30f;
    bool _inGame = false;

    [SerializeField] TextMeshProUGUI _textTimer;
    [SerializeField] Image _imgPoison;
    [SerializeField] GameObject _gameOver;

    [SerializeField] Image _imgTransition;

    private void Awake()
    {
        instanceGameManager = this;

        for (int i = 0; i < poolGrille.poolElements.Count; i++)
        {
            PoolElement poolElement = new PoolElement();
            poolElement.maxLevel = poolGrille.poolElements[i].maxLevel;
            poolElement.grilles = new List<Grille>(poolGrille.poolElements[i].grilles);
            poolElement.isRandom = poolGrille.poolElements[i].isRandom;
            copyPoolGrille.Add(poolElement);
        }

        _gameOver.SetActive(false);
    }

    private void Start()
    {
        _intCurrentLevel = 0;
        StartGame();
        //StartCoroutine(Transition());
    }

    private void Update()
    {
        if (_inGame)
        {
            _timer -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_timer);
            _textTimer.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            _imgPoison.fillAmount = Mathf.Clamp01(_timer / 30f);

            if (_timer < 0)
            {
                GameOver();
            }
        }
    }

    public void VerifPatternComplete()
    {
        if (_currentGrille.VerifGrille())
        {
            Debug.Log("c'est gagné");
            OnWin?.Invoke();
            _intCurrentLevel++;
            Destroy(_currentGrille.gameObject);
            StartGame();
        }
    }

    private void GameOver()
    {
        _inGame = false;
        _gameOver.SetActive(true);
        Destroy(_currentGrille.gameObject);
    }

    private void StartGame()
    {
        _currentGrille = Instantiate(poolGrille.GetGrille(_intCurrentLevel, copyPoolGrille));
        _currentGrille.transform.position = _anchorGrille.position;
        _inGame = true;
        _timer = 30f;
        _imgPoison.fillAmount = 0;
    }

    private IEnumerator Transition()
    {
        float temps = 0f;
        float duree = 1f;

        while (temps < duree)
        {
            temps -= Time.deltaTime;

            float pourcentageTransparence = temps / duree;
            _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, pourcentageTransparence);

            yield return null;
        }
        _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 0f);
    }
}
