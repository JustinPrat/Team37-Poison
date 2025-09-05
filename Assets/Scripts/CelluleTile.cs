using DG.Tweening;
using UnityEngine;

public class CelluleTile : MonoBehaviour
{
    private bool aboveCorrectCelluleHolder;
    private bool canDrag = true;

    private CelluleHolder _cellule;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private ParticleSystem _spawnParticles;

    public ParticleSystem SpawnParticles => _spawnParticles;

    public Animator animator => _animator;

    public static CelluleTile currentCellule;

    public Cellule ownCellule;

    public Texture2D cursorTextureGrab;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void SetGrabbable(bool isGrabbable)
    {
        canDrag = isGrabbable;
    }

    #region Drag and Drop
    private void OnMouseUp()
    {
        if (aboveCorrectCelluleHolder)
        {
            canDrag = false;
            transform.position = _cellule.transform.position;
            _cellule.lockedInPattern = true;

            SoundManager.instance.PlacingPiece();
            GameManager.instanceGameManager.VerifPatternComplete();
        }

        _animator.SetTrigger("squishout");
        currentCellule = null;
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    private void OnMouseDrag()
    {
        if (canDrag)
        {
            if (currentCellule != this)
            {
                _animator.SetTrigger("squish");
                //Cursor.SetCursor(cursorTextureGrab, hotSpot, cursorMode);
            }

            SoundManager.instance.PieceMoving();
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            currentCellule = this;
        }
    }
    #endregion
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CelluleHolder>())
        {
            CelluleHolder celluleHolder = collision.GetComponent<CelluleHolder>();
            Cellule cellule = collision.GetComponent<Cellule>();

            if (cellule.tileForm.Equals(this.GetComponent<Cellule>().tileForm) && !celluleHolder.lockedInPattern)
            {
                aboveCorrectCelluleHolder = true;
                _cellule = cellule.GetComponent<CelluleHolder>();
                //Debug.Log("IN correct cellule holder");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aboveCorrectCelluleHolder = false;
        //Debug.Log("OUT correct cellule holder");
    }
}
