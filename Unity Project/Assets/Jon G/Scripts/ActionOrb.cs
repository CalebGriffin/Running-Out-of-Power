using UnityEngine;

public class ActionOrb : MonoBehaviour
{
    [SerializeField] private static PlayerController Player()
    { return FindObjectOfType<PlayerController>(); }
    [SerializeField] private string intendedAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoAssignedAction(intendedAction);
    }

    private void DoAssignedAction(string action)
    {
        if (action == "Dash")
        { Player().Action_Dash(); }

        if (action == "Jump")
        { Player().Action_Jump(false); }

        if (action == "Flip")
        { Player().Action_Flip(false); }

        Player().powerLevel += 1;

        //this.gameObject.SetActive(false);
    }
}
