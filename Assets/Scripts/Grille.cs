using Alchemy.Inspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Grille : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;
    public Sprite grilleSprite;

#if UNITY_EDITOR
    [Button]
    private void InitGrille(int x, int y)
    {
        DestroyGrille();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Cellule cellule = PrefabUtility.InstantiatePrefab(cellulePrefab, this.transform).GetComponent<Cellule>();
                cellule.GetComponent<CelluleHolder>().lockedInPattern = false;
                cellule.transform.position = new Vector3(i, j, 0);
            }
        }
    }

    [Button]
    private void UpdateSprites ()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            transform.GetChild(i).GetComponent<Cellule>().GetSprite();
        }
    }
#endif

    private void DestroyGrille()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            #if UNITY_EDITOR
                DestroyImmediate(transform.GetChild(i).gameObject);
            #endif
        }
    }

    public bool VerifGrille()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            if (!transform.GetChild(i).GetComponent<CelluleHolder>().lockedInPattern)
            {
                return false;
            }
        }
        return true;
    }
}
