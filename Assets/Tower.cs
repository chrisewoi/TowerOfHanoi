using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Image towerBase, towerHeight;
    public Transform towerAnchor;


    public void AssignColor(Color newColor)
    {
        float darkerAmount = 0.1f;
        Color darkerColor = new Color(newColor.r - darkerAmount, newColor.g - darkerAmount, newColor.b - darkerAmount);

        towerBase.color = darkerColor;
        towerHeight.color = newColor;

    }

    public Transform GetTopTile()
    {
        return towerAnchor.childCount > 0 ? towerAnchor.GetChild(0) : null;
    }

    public float GetTopTileSize()
    {
        return GetTopTile().transform.localScale.x;
    }
}
