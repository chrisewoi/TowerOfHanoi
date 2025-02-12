using UnityEngine;

[CreateAssetMenu(fileName = "ColourPalette")]//, menuName = "Scriptable Objects/ColourPalette")]
public class ColourPalette : ScriptableObject
{
    // Ask for the necessary colour options in our game.
    public Color backgroundColor;
    public Color towerColor, towerHighlight;
    public Color tile1Color, tile2Color, tile3Color, tile4Color, tile5Color;
    public Color textColor;
}
