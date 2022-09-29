using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    private IEnumerator ToggleLeft()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        
        if (!(canGoLeft))
        { yield return null; }
        
        if (currentAction != CurrentAction.Run)
        { currentAction--; }
        else { currentAction = CurrentAction.Flip; }

        yield return null;
    }

    private IEnumerator ToggleRight()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        
        if (!(canGoRight))
        { yield return null; }
        
        if (currentAction != CurrentAction.Flip)
        { currentAction++; }
        else { currentAction = CurrentAction.Run; }
        
        yield return null;
    }
}
