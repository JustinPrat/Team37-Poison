using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCellule : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;

    [SerializeField] Transform anchorSpawnCellule;
    [SerializeField] Transform anchorPreSpawnCellule;

    private Cellule _cellule;

    private void Start()
    {
        CelluleSpawn();
    }

    public void ReadSquareInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(_cellule.tileForm.baseForm);
            if (_cellule.tileForm.baseForm == Base.None)
            {
                Debug.Log("Square");
                _cellule.tileForm.baseForm = Base.Square;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("fold");
            }
            else
            {
                Debug.Log("Naaan");
            }
        }
    }

    public void ReadCircleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(_cellule.tileForm.baseForm);
            if (_cellule.tileForm.baseForm == Base.None)
            {
                _cellule.tileForm.baseForm = Base.Circle;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("fold");
            }
            else
            {
                Debug.Log("Naaan");
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
                _cellule.tileForm.baseForm = Base.Triangle;
                _cellule.GetComponent<CelluleTile>().animator.SetTrigger("fold");
            }
            else
            {
                Debug.Log("Naaan");
            }
        }
    }

    public void ReadArrowUpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.tileForm.arrowUp = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowDownInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.tileForm.arrowDown = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowRightInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.tileForm.arrowRight = true;
            _cellule.GetSprite();
        }
    }

    public void ReadArrowLeftInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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
                _cellule.transform.position = anchorSpawnCellule.position;
                CelluleTile celluleTile = _cellule.GetComponent<CelluleTile>();
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
            CelluleTile.currentCellule.transform.Rotate(0f, 0f, 90f);
            CelluleTile.currentCellule.ownCellule.Turn();
        }
    }
}
