using UnityEngine;

public class Cellule : MonoBehaviour
{
    public Base baseForm;
    public bool arrowUp = false;
    public bool arrowDown = false;
    public bool arrowRight = false;
    public bool arrowLeft = false;
}

public enum Base {
    None,
    Square,
    Circle,
    Triangle
}
