using UnityEngine;

public class Cellule : MonoBehaviour
{
    public Base baseForm;
    public bool arrowUp = false;
    public bool arrowDown = false;
    public bool arrowRight = false;
}

public enum Base {
    None,
    Square,
    Circle,
    Triangle
}
