using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCellule : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;

    [SerializeField] Transform anchorSpawnCellule;
    [SerializeField] Transform anchorPreSpawnCellule;

    private Cellule _cellule;

    private List<Cellule> _listCellule = new List<Cellule>();

    private void Start()
    {
        CelluleSpawn();
        GameManager.instanceGameManager.OnWin += DestroyElements;
    }

    private void OnDestroy()
    {
        GameManager.instanceGameManager.OnWin -= DestroyElements;
    }

    private void DestroyElements ()
    {
        for (int i = _listCellule.Count - 1; i >= 0; i--)
        {
            if (_listCellule[i] != null)
                Destroy(_listCellule[i].gameObject);
        }

        _listCellule.Clear();
    }

    public void ReadSquareInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_cellule.tileForm.baseForm == Base.None)
            {
                SoundManager.instance.CraftingPiece();
                _cellule.tileForm.baseForm = Base.Square;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("spawn");
            }
        }
    }

    public void ReadCircleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_cellule.tileForm.baseForm == Base.None)
            {
                SoundManager.instance.CraftingPiece();
                _cellule.tileForm.baseForm = Base.Circle;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("spawn");
            }
        }
    }

    public void ReadTriangleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(_cellule.tileForm.baseForm);
            if (_cellule.tileForm.baseForm == Base.None)
            {
                SoundManager.instance.CraftingPiece();
                _cellule.tileForm.baseForm = Base.Triangle;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("spawn");
            }
        }
    }

    public void ReadArrowUpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SoundManager.instance.CraftingPiece();
            _cellule.tileForm.arrowUp = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowDownInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SoundManager.instance.CraftingPiece();
            _cellule.tileForm.arrowDown = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowRightInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SoundManager.instance.CraftingPiece();
            _cellule.tileForm.arrowRight = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowLeftInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SoundManager.instance.CraftingPiece();
            _cellule.tileForm.arrowLeft = true;
            _cellule.GetSprite();
        }
    }

    public void ReadValidateInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_cellule.tileForm.baseForm != Base.None)
            {
                CelluleTile celluleTile = _cellule.GetComponent<CelluleTile>();

                Vector3 cellulePos = new Vector3(Random.Range(anchorSpawnCellule.position.x - 2, anchorSpawnCellule.position.x + 2),
                    Random.Range(anchorSpawnCellule.position.y - 1, anchorSpawnCellule.position.y + 1), anchorSpawnCellule.position.z);
                _cellule.transform.position = cellulePos;

                _listCellule.Add(_cellule);
                celluleTile.animator.SetTrigger("drop");
                celluleTile.SetGrabbable(true);

                CelluleSpawn();
            }
        }
    }


    private void CelluleSpawn ()
    {
        _cellule = Instantiate(cellulePrefab);
        _cellule.transform.position = anchorPreSpawnCellule.position;
        CelluleTile celluleTile = _cellule.GetComponent<CelluleTile>();
        celluleTile.SetGrabbable(false);
    }

    public void ReadRotateInput(InputAction.CallbackContext context)
    {
        Debug.Log("et la");
        if (context.performed && CelluleTile.currentCellule != null)
        {
            Debug.Log("ok je suis ici");
            //CelluleTile.currentCellule.transform.Rotate(0f, 0f, -90f);
            CelluleTile.currentCellule.ownCellule.Turn();
        }
    }
}
