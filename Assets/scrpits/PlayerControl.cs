using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector2 currentTile, nextTile;
    bool moving;
    public float speedM;
    public LayerMask wallMask;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-6.5f,-0.5f);
        moving=false;
        currentTile=transform.position;
        nextTile=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving){
            transform.position=Vector2.MoveTowards(transform.position, nextTile,speedM*Time.deltaTime);
            if((Vector2)transform.position==nextTile){
                currentTile=nextTile;
                moving=false;
            }
        }
        else{
            if(Input.GetKey(KeyCode.D)) nextTile=CheckNextTile(Directions.Right);
            if(Input.GetKey(KeyCode.A)) nextTile=CheckNextTile(Directions.Left);
            if(Input.GetKey(KeyCode.W)) nextTile=CheckNextTile(Directions.Up);
            if(Input.GetKey(KeyCode.S)) nextTile=CheckNextTile(Directions.Down);
            if (currentTile != nextTile)
            {
                moving = true;
            }
        }
    }
    Vector2 CheckNextTile(Directions direction){
        Vector2 tempTile=currentTile;
        Vector2 rayDirection=Vector2.zero;
        switch(direction){
            case Directions.Right:
                rayDirection=Vector2.right;
            break;
            case Directions.Left:
            rayDirection=Vector2.left;
            break;
            case Directions.Up:
            rayDirection=Vector2.up;
            break;
            case Directions.Down:
            rayDirection=Vector2.down;

            break;
        }
        
        bool check = Physics2D.Raycast(tempTile,rayDirection,1,wallMask);
        if (check==false)
        {
            tempTile+=rayDirection;
        }
        return tempTile;
    }
}
