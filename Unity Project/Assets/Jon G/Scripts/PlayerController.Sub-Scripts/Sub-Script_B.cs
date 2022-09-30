using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    private void Action_Run()
    {
        if (powerLevel < runCost) { return; }

        running = !(running);
    }
    private void Run_Extension()
    {
        if (powerLevel < runCost) { running = false; return; }

        if (!(running)) { return; }

        RigidBody().AddForce((new Vector2(MoveSpeed() * Direction(), 0f)) - RigidBody().velocity, ForceMode2D.Force);
    }
    public void Action_Dash()
    {
        RigidBody().AddForce(new Vector2(15f, 0f), ForceMode2D.Impulse);
    }

    public void Action_Jump(bool manual)
    {
        if ((powerLevel < jumpCost) && manual) { return; }

        RigidBody().velocity = new Vector2(RigidBody().velocity.x, 0f);
        RigidBody().AddForce(new Vector2(0f, jumpForce * RigidBody().mass), ForceMode2D.Impulse);
    }

    public void Action_Flip(bool manual) 
    {

        if ((powerLevel < flipCost) && manual) { return; }

        flipped = !(flipped);
    }
}
