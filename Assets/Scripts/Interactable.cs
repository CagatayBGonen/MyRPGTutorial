using UnityEngine;

public class Interactable : MonoBehaviour
{
    //the distance for how close player need to be to interact with the related obj.
    public float radius = 3f;
    //variable for 
    public Transform interactionTransform;
    //Checks if plauer is focused
    bool isFocus = false;
    //reference to the player transform
    Transform player;
    //We do not what to update every time of interaction
    //check if we interacted
    bool hasInteracted = false;
    //this class will be a base class, we are using virtual to override this method so that we can customize it
    public virtual void Interact()
    {
        //this method is meant to be overwritten
        Debug.Log($"Interact with{transform.name}");
    }
    void Update()
    {
        //checks everyframe if the player is focused
        if (isFocus && !hasInteracted)
        {
            //variable for the distance between player and interactable obj
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            //checks if player is in the range of interaction
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    //Set Focus situation
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    //Set unfocus situation
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted=false;
    }
    //visualizing the radius
    private void OnDrawGizmosSelected()
    {
        //seting the color
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
