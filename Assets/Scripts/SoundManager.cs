using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource _audioSourceHealth;
    public AudioSource _audioSourceMusic;

    public AudioSource _audioSourceClip;

    public AudioClip _audioClipCrafting;
    public AudioClip _audioClipPlacing;
    public AudioClip _audioClipGameOver;
    public AudioClip _audioClipLevelComplete;
    public AudioClip _audioClipPieceMoving;

    private void Start()
    {
        SoundManager.instance = this;
    }

    public void CraftingPiece()
    {
        _audioSourceClip.resource = _audioClipCrafting;
        _audioSourceClip.Play();
    }

    public void PlacingPiece()
    {
        _audioSourceClip.resource= _audioClipPlacing;
        _audioSourceClip.Play();
    }

    public void GameOver()
    {
        _audioSourceHealth.Stop();
        _audioSourceMusic.volume = 0.1f;
        //_audioSourceMusic.Stop();
        _audioSourceClip.resource=_audioClipGameOver;
        _audioSourceClip.Play();
    }

    public void LevelComplete()
    {
        _audioSourceClip.resource = _audioClipLevelComplete;
        _audioSourceClip.Play();
    }

    public void PieceMoving()
    {
        _audioSourceClip.resource = _audioClipPieceMoving;
        _audioSourceClip.Play();
    }
}
