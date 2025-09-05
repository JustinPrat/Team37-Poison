using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayQuit : MonoBehaviour
{
    [SerializeField] private string _nameSceneJeu;

    [SerializeField] private Image _imgTransition;

    [SerializeField] AudioSource _audioSourcePlay;
    [SerializeField] AudioSource _audioSourceQuit;
    [SerializeField] AudioSource _audioSourceRetry;

    private void Start()
    {
        _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 1f);
        StartCoroutine(Transition1to0());
    }
    public void Play()
    {
        _audioSourcePlay.Play();
        Debug.Log("debur");
        //SceneManager.LoadScene(_nameSceneJeu);
        StartCoroutine(Transition0to1(_nameSceneJeu));
    }

    public void Quit()
    {
        _audioSourceQuit.Play();
        Debug.Log("fin");
        Application.Quit();
    }

    public void Retry()
    {
        _audioSourceRetry.Play();
        StartCoroutine(Transition0to1("Menu"));
    }

    private IEnumerator Transition0to1(string nameScene)
    {
        //_imgTransition.enabled = true;
        float temps = 0f;
        float duree = 1f;

        while (temps < duree)
        {
            temps += Time.deltaTime;

            float pourcentageTransparence = temps / duree;
            _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, pourcentageTransparence);

            yield return null;
        }

        _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 1f);
        //_imgTransition.enabled = false;
        SceneManager.LoadScene(nameScene);
    }

    private IEnumerator Transition1to0()
    {
        //_imgTransition.enabled = true;
        float temps = 0f;
        float duree = 1f;
        while (temps < duree)
        {
            temps += Time.deltaTime;

            float pourcentageTransparence = temps / duree;
            _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 1 - pourcentageTransparence);

            yield return null;
        }

        _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 0f);
        //_imgTransition.enabled = false;
    }
}
