using UnityEngine;

public class ModifySprite : MonoBehaviour
{
    [SerializeField]
    private Cellule _cellule;

    [SerializeField]
    private CelluleTile _celluleTile;

    public void UpdateSprite ()
    {
        _cellule.GetSprite();
    }

    public void PlaySpawnParticles ()
    {
        _celluleTile.SpawnParticles.Play();
    }
}
