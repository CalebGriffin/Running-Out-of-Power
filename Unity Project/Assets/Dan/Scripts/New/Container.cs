using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container 
{
    private int blockId;
    private Transform[,] blocks = new Transform[10, 2];
    public Container(int blockId, float leftSide, float rightSide, Transform blueBlock, Transform redBlock){
        this.blockId = blockId;
        CreateContainerBlocks(leftSide, rightSide, blueBlock, redBlock);
    }

    private void CreateContainerBlocks(float leftSide, float rightSide, Transform blueBlock, Transform redBlock){
        
        for(int i = 0; i < blocks.GetLength(0); i++){
            //Hardcoded testing purposes
            //blocks[i, 0] = blueBlock;
            //blocks[i, 1] = redBlock;
            int rand = Random.Range(0, 2);
            int randomHeight = Random.Range(2, 5);
            ///Debug.Log(randomHeight);
            
            int height = 7 + (i * randomHeight);
            blocks[i, rand] = GameObject.Instantiate(blueBlock, new Vector2(rand == 0 ? leftSide : rightSide, height), Quaternion.identity);
            blocks[i, rand == 0 ? 1 : 0] = GameObject.Instantiate(redBlock, new Vector2(rand == 0 ? rightSide : leftSide, height), Quaternion.identity);
        }
    }

    public void SwitchBlocks(){
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            //Hardcoded testing purposes
            Vector3 temp = blocks[i, 0].position;
            LeanTween.moveX(blocks[i, 0].gameObject, blocks[i, 1].position.x, 0.1f);
            LeanTween.moveX(blocks[i, 1].gameObject, temp.x, 0.1f);
            //blocks[i, 0].position = blocks[i, 1].position;
            //blocks[i, 1].position = temp;
        }
    }
    //The blue block and the orange block will have ids (blue 0, orange 1)
    //The container's block id will determine which block it wants on the left hand side
    //E.G. if this container has an id of 0 it wants the blue blocks to land on the left side
    public int GetBlockId() => blockId;
}
