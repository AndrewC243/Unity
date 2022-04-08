using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    Transform test;
    bool myTurn;
    int moveCount;
    public static GameObject Test;

    async void Start() {
        test = GetComponent<Transform>();
        myTurn = false;
        moveCount = 3;
        }

        async void Update() {
        myTurn = moveCount > 0;
        while (myTurn) {
            if (Input.GetKeyDown(KeyCode.W)) {
                test.Translate(new Vector3(0, 0, 1));
                moveCount--;
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                test.Translate(new Vector3(0, 0, -1));
                moveCount--;
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                test.Translate(new Vector3(-1, 0, 0));
                moveCount--;
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                test.Translate(new Vector3(1, 0, 0));
                moveCount--;
            }
            if(moveCount <= 0) {
                myTurn = false;
                break;
            }
        }
    }

    public bool getFriendlyTurn() { // Naming was because I was originally going to make a full team in this class, but wasn't sure if that was the greatest idea
        return myTurn;
    }
    
    public void changeTurn() { // I don't have the time in class to make a full system for clicking and selecting characters to move, so instead they'll move 1 at a time with WASD
        myTurn = !myTurn;
    }

    public static GameObject inst(float x, float y, float z) { // I don't even know man, I'm just trying whatever I can to make this game work
        return Instantiate(Test, new Vector3(x, y, z), Quaternion.identity);
    }
}
