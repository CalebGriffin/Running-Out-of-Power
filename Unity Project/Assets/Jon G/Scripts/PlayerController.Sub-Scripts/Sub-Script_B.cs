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

        RigidBody().AddForce((new Vector2(MoveSpeed() * Direction(), 0f) * RigidBody().mass) - RigidBody().velocity, ForceMode2D.Force);
    }

    private void Action_Jump()
    {
        if (powerLevel < jumpCost) { return; }
        
        RigidBody().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void Action_Flip() 
    {
        if (powerLevel < flipCost) { return; }

        flipped = !(flipped);
    }
}
