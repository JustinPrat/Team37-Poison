using UnityEngine;

public class Grille : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;

    private void InitGrille(int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Instantiate(cellulePrefab);
            }
        }
    }
}
