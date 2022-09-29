using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    private IEnumerator ToggleLeft()
    {

        if (!(canGoLeft) || mustReset)
        {
            yield return new WaitForSecondsRealtime(0.15f);
            yield return null; 
        }

        mustReset = true;

        if (currentAction != CurrentAction.Run)
        { currentAction--; }
        else { currentAction = CurrentAction.Flip; }

        ChangeColour(CurrentColour());

        yield return new WaitForSecondsRealtime(0.15f);
        mustReset = false;
        yield return null;
    }

    private IEnumerator ToggleRight()
    {

        if (!(canGoRight) || mustReset)
        {
            yield return new WaitForSecondsRealtime(0.15f);
            yield return null;
        }

        mustReset = true;

        if (currentAction != CurrentAction.Flip)
        { currentAction++; }
        else { currentAction = CurrentAction.Run; }

        ChangeColour(CurrentColour());

        yield return new WaitForSecondsRealtime(0.15f);
        mustReset = false;
        yield return null;
    }

    private void ChangeColour(Color colour)
    {
        Sprite().color = colour;
    }
}
