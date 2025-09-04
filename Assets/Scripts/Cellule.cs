using Alchemy.Inspector;
using UnityEngine;

public class Cellule : MonoBehaviour
{
    public TileForm tileForm;
    public SpriteSelect spriteSelect;

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteConnectionUp;
    public SpriteRenderer spriteConnectionDown;
    public SpriteRenderer spriteConnectionLeft;
    public SpriteRenderer spriteConnectionRight;

    [Button]
    public void GetSprite ()
    {
        if (spriteSelect.baseSprites.ContainsKey(tileForm.baseForm))
        {
            spriteRenderer.sprite = spriteSelect.baseSprites[tileForm.baseForm];
        }

        spriteConnectionUp.sprite = tileForm.arrowUp ? spriteSelect.connectionSprites[Connection.Up] : null;
        spriteConnectionDown.sprite = tileForm.arrowDown ? spriteSelect.connectionSprites[Connection.Down] : null;
        spriteConnectionLeft.sprite = tileForm.arrowLeft ? spriteSelect.connectionSprites[Connection.Left] : null;
        spriteConnectionRight.sprite = tileForm.arrowRight ? spriteSelect.connectionSprites[Connection.Right] : null;
    }

    public void Turn()
    {
        bool _arrowUp = false;
        bool _arrowDown = false;
        bool _arrowLeft = false;
        bool _arrowRight = false;

        if (tileForm.arrowUp)
        {
            _arrowRight = true;
        }
        if (tileForm.arrowRight)
        {
            _arrowDown = true;
        }
        if (tileForm.arrowDown)
        {
            _arrowLeft = true;
        }
        if (tileForm.arrowLeft)
        {
            _arrowUp = true;
        }

        tileForm.arrowUp = _arrowUp;
        tileForm.arrowRight = _arrowRight;
        tileForm.arrowDown = _arrowDown;
        tileForm.arrowLeft = _arrowLeft;
    }
}
