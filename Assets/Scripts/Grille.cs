using Alchemy.Inspector;
using UnityEngine;

public class Grille : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;

    [Button]
    private void InitGrille(int x, int y)
    {
        DestroyGrille();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Cellule cellule = Instantiate(cellulePrefab, this.transform);
                cellule.transform.position = new Vector3(i, j, 0);
            }
        }
    }

    private void DestroyGrille()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            #if UNITY_EDITOR
                DestroyImmediate(transform.GetChild(i).gameObject);
            #endif
        }
    }
}
