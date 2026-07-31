using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float HP = 100f;

    
    void Start()
    {        
        Debug.Log("mouse removed");
        LockCursor();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

     void  LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;//remove coursor from vieew
    }
     void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;//Unhide Cursor 
    }
    
}
