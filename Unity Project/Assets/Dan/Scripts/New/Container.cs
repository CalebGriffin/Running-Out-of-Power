using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container 
{
    private float desiredPosition;
    private Transform[,] blocks = new Transform[60, 2];
    public Container(float desiredPosition, float leftSide, float rightSide, Transform blueBlock, Transform redBlock){
        this.desiredPosition = desiredPosition;
        CreateContainerBlocks(leftSide, rightSide, blueBlock, redBlock);
    }

    private void CreateContainerBlocks(float leftSide, float rightSide, Transform blueBlock, Transform redBlock){
        int startingHeight = 7;
        for(int i = 0; i < blocks.GetLength(0); i++){
            int rand = Random.Range(0, 2);
            int randomHeight = Random.Range(3, 7);

            int height = startingHeight + randomHeight;
            startingHeight = height;

            blocks[i, rand] = GameObject.Instantiate(blueBlock, new Vector2(rand == 0 ? leftSide : rightSide, height), Quaternion.identity);
            blocks[i, rand == 0 ? 1 : 0] = GameObject.Instantiate(redBlock, new Vector2(rand == 0 ? rightSide : leftSide, height), Quaternion.identity);
        }
        blocks[blocks.GetLength(0) - 1, 0].GetComponent<Blocks>().isLast = true;
        blocks[blocks.GetLength(0) - 1, 1].GetComponent<Blocks>().isLast = true;
    }

    public void SwitchBlocks(){
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            //Swap the position of each object;
            Vector3 temp = blocks[i, 0].position;
            LeanTween.moveX(blocks[i, 0].gameObject, blocks[i, 1].position.x, 0.1f);
            LeanTween.moveX(blocks[i, 1].gameObject, temp.x, 0.1f);
        }
    }
    public bool AreBlocksPlacedCorrectly(float position) => desiredPosition == position ? true : false;
}
