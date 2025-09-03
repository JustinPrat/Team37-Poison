using UnityEngine;

public class CelluleTile : MonoBehaviour
{

    private bool inCorrectCelluleHolder;
    private bool canDrag = true;

    private CelluleHolder _cellule;

    #region Drag and Drop
    private void OnMouseUp()
    {
        if (inCorrectCelluleHolder)
        {
            canDrag = false;
            transform.position = _cellule.transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (canDrag)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<CelluleHolder>())
        {
            _cellule = collision.GetComponent<CelluleHolder>();
            Cellule cellule = _cellule.GetComponent<Cellule>();

            if (cellule.tileForm.Equals(this.GetComponent<Cellule>().tileForm))
            {
                inCorrectCelluleHolder = true;
                Debug.Log("c'est ok");
            }
            Debug.Log("ta mere");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCorrectCelluleHolder = false;
    }
}
