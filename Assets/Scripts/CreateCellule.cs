using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCellule : MonoBehaviour
{
    [SerializeField] Cellule cellulePrefab;

    [SerializeField] private Cellule _cellule;

    private void Start()
    {
        _cellule = Instantiate(cellulePrefab);
    }

    public void ReadSquareInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(_cellule.baseForm);
            if (_cellule.baseForm == Base.None)
            {
                Debug.Log("Square");
                _cellule.baseForm = Base.Square;
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
            Debug.Log(_cellule.baseForm);
            if (_cellule.baseForm == Base.None)
            {
                _cellule.baseForm = Base.Circle;
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
            Debug.Log(_cellule.baseForm);
            if (_cellule.baseForm == Base.None)
            {
                _cellule.baseForm = Base.Triangle;
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
            _cellule.arrowUp = true;
        }
    }

    public void ReadArrowDownInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.arrowDown = true;
        }
    }

    public void ReadArrowRightInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.arrowRight = true;
        }
    }

    public void ReadArrowLeftInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _cellule.arrowLeft = true;
        }
    }

    public void ReadValidateInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Pour valider
            _cellule = Instantiate(cellulePrefab);
        }
    }
}
