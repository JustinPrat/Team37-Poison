using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayQuit : MonoBehaviour
{
    [SerializeField] private string _nameSceneJeu;

    [SerializeField] private Image _imgTransition;

    private void Start()
    {
        _imgTransition.color = new Color(_imgTransition.color.r, _imgTransition.color.g, _imgTransition.color.b, 0f);
    }
    public void Play()
    {
        Debug.Log("debur");
        //SceneManager.LoadScene(_nameSceneJeu);
        StartCoroutine(Transition());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator Transition()
    {
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
        SceneManager.LoadScene(_nameSceneJeu);
    }
}
