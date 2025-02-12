using UnityEngine;

public class TileAnimations : MonoBehaviour
{
    // Get tile's animator
    private Animator myAni;

    void Awake()
    {
        myAni = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    /*
     * Trigger the rising animation
     * Prompted in game
     */

    public void StartRise()
    {
        myAni.SetTrigger("Rise");
    }

    /*
    * Trigger the falling animation
    * Prompted in game
    */
    public void StartFall()
    {
        myAni.SetTrigger("Fall");

    }
}
