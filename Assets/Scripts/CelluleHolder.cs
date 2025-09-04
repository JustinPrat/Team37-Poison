using UnityEngine;

public class CelluleHolder : MonoBehaviour
{
    public Cellule cellule;

    [HideInInspector]
    public bool lockedInPattern = false;

    private void Start()
    {
        if (cellule.tileForm.baseForm == Base.None)
        {
            lockedInPattern = true;
        }
    }
}
