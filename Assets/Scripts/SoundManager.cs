using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource _audioSource;

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
        _audioSource.resource = _audioClipCrafting;
        _audioSource.Play();
    }

    public void PlacingPiece()
    {
        _audioSource.resource= _audioClipPlacing;
        _audioSource.Play();
    }

    public void GameOverPiece()
    {
        _audioSource.resource=_audioClipGameOver;
        _audioSource.Play();
    }

    public void LevelComplete()
    {
        _audioSource.resource = _audioClipLevelComplete;
        _audioSource.Play();
    }

    public void PieceMoving()
    {
        _audioSource.resource = _audioClipPieceMoving;
        _audioSource.Play();
    }
}
