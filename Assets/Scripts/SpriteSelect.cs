using System;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Serialization;
using Alchemy.Inspector;

[CreateAssetMenu(fileName = "SpriteSelect", menuName = "Poison37/SpriteSelect", order = 1)]
[AlchemySerialize]
public partial class SpriteSelect : ScriptableObject
{
    [AlchemySerializeField, NonSerialized]
    public Dictionary<Base, Sprite> baseSprites;

    [AlchemySerializeField, NonSerialized]
    public Dictionary<Connection, Sprite> connectionSprites;
}

[Serializable]
public struct TileForm
{
    public Base baseForm;
    public bool arrowUp;
    public bool arrowDown;
    public bool arrowRight;
    public bool arrowLeft;


}

public enum Base
{
    None,
    Square,
    Circle,
    Triangle
}

public enum Connection
{
    Up,
    Down,
    Left,
    Right
}
