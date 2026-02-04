using UnityEngine;
using TMPro;
using System.Collections;

public class Game : MonoBehaviour
{
    public GameManager gameManager;

    private CanvasGroup canvasGroup;
    // Which tower has the player just selected
    public Tower selectedTower;

    // Collection of all the towers
    public Tower[] towers;

    // Colour palette
    public Color regularColor, highlightedColor;

    // Text PROPERTY; counting the number of movement. Property to push update to UI field
    public TMP_Text turnTextDisplay;

    private int turnCounter;

    // How long between rise and fall animations
    public float animationTime = 0.5f;

    public int turnProperty
    {
        get
        {
            return turnCounter;
        }
        set
        {
            turnCounter = value;
            turnTextDisplay.text = turnCounter.ToString();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ApplyPalette();
        canvasGroup = GetComponentInParent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        canvasGroup.alpha += animationTime * Time.deltaTime;
    }
    
    /* 
     * Triggered by our unity Buttons
     * if I don't have a tower selected, be the tower we just clicked
     * if the tower I click is my selected tower, deselect (set to null)
     * otherwise, perform a movement between the selectedTower and the new tower.
     * Trigger the 'ApplyPalette' function regardless of result
     */

    public void SelectTower(Tower newTower)
    {
        if (selectedTower == null)
        {
            selectedTower = newTower;
            //print("Selected tower is " + selectedTower.name);
        }
        else if (newTower == selectedTower)
        {
            selectedTower = null;
        } else
        {
            StartCoroutine(MoveTiles(selectedTower, newTower));
            selectedTower = null;
        }

        ApplyPalette();
        gameManager.CheckGameOver();
    }

    /*
     * Take the top tile we want to move 
     * if there isn't one, stop the function! (we can't move from empty tower)
     * Compare it with the tile at our target tower
     * If the target tower is empty, move
     * or if the top tile is < target tile, move
     * move = reassign parents as the tagetTower's parent
     * 
     * UPDATED
     * updated to IEnumerator, allowing for the function to take place over multiple frames
     * WaitForSeconds() will delay the movement, allowing us to trigger TileAnimations.
     * Remember to use IEnumerators with StartCoroutine() as you call them.
     * Also, we had turnProperty increase with each successful movement
     */
    public IEnumerator MoveTiles(Tower fromTower, Tower toTower)
    {
        //print("Moving from " + fromTower.name + " to " + toTower.name);
        Transform topTile = fromTower.GetTopTile();
        if (topTile == null) yield return null;

        Transform targetTile = toTower.GetTopTile();
        if (targetTile == null ||
            topTile.GetComponent<RectTransform>().rect.width
            < targetTile.GetComponent<RectTransform>().rect.width)
        {
            topTile.GetComponentInChildren<TileAnimations>().StartRise();
            yield return new WaitForSeconds(animationTime);
            topTile.SetParent(toTower.towerAnchor);
            topTile.SetSiblingIndex(0);
            turnProperty++;
            topTile.GetComponentInChildren<TileAnimations>().StartFall();
        }
        
        gameManager.CheckGameOver();
    }

    /*
     * Every tower will change colour to 'regularColor'
     * selectedTower is overridden with 'highlightedColor'
     */

    public void ApplyPalette()
    {
        foreach( Tower tower in towers)
            tower.AssignColor(regularColor);

        if (selectedTower != null)
            selectedTower.AssignColor(highlightedColor);
    }
}
