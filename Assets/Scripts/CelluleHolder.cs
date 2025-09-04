using UnityEngine;

public class CelluleHolder : MonoBehaviour
{
    public Cellule cellule;

    private TileForm tileFormEmpty;

    [HideInInspector]
    public bool inPattern = false;

    private void Start()
    {
        tileFormEmpty.baseForm = Base.None;
        tileFormEmpty.arrowUp = false;
        tileFormEmpty.arrowDown = false;
        tileFormEmpty.arrowLeft = false;
        tileFormEmpty.arrowRight = false;
    }

    public void VerifEmptyCellule()
    {
        if (cellule.tileForm.Equals(tileFormEmpty))
        {
            inPattern = true;
        }
    }
}
