using System;
using UnityEngine;

public class Init : MonoBehaviour {
   public GameObject prefab; // GameObjects specified through the interface in the engine
   public GameObject player;
   public PlayerSprite[] t1sprites;
   public PlayerSprite[] t2sprites;

   async void Start()
   {
       for (int x = 0; x < 10; x++) {
           for (int z = 0; z < 10; z++) {
               Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity); // Create ground tiles
           }
       }

       t1sprites = new PlayerSprite[4]; // Initialization, 4 sprites per tean
       t2sprites = new PlayerSprite[4];

       for (int i = 0; i < t1sprites.Length; i++) {
               t1sprites[i] = PlayerSprite.inst(i / 2, (float)0.9, 0);
       }
      
      /*
        Formerly:
        
        for (int i = 0; i < t1sprites.length; i++) {
            t1sprites[i] = new PlayerSprite();
            t1sprites[i].inst(i * 2, (float)0.9, 0);
        }
         
      */

        for (int i = 0; i < t2sprites.Length; i++) {
               t1sprites[i] = PlayerSprite.inst(i / 2, (float)0.9, 0);
       }
        
   }
    private async void Update() {


            // // RUN THROUGH FULL TEAM ONE AT A TIME
            t1sprites[0].changeTurn();
            if (!t1sprites[0].getFriendlyTurn()) t1sprites[1].changeTurn();
            if (!t1sprites[0].getFriendlyTurn() & !t1sprites[1].getFriendlyTurn()) { Debug.Log("This works"); t1sprites[2].changeTurn(); }
            if (!t1sprites[0].getFriendlyTurn() & !t1sprites[1].getFriendlyTurn() & !t1sprites[2].getFriendlyTurn()) t1sprites[3].changeTurn();

            var trueForAll = true;
            foreach(PlayerSprite p in t1sprites) {
                if (!p.getFriendlyTurn()) trueForAll = false;
            }
            
            if (trueForAll) {
                t2sprites[0].changeTurn();
                if (!t2sprites[0].getFriendlyTurn()) t2sprites[1].changeTurn();
                if (!t2sprites[0].getFriendlyTurn() & !t2sprites[1].getFriendlyTurn()) t2sprites[2].changeTurn();
                if (!t2sprites[0].getFriendlyTurn() & !t2sprites[1].getFriendlyTurn() & !t2sprites[2].getFriendlyTurn()) t2sprites[3].changeTurn();
            }
        }
    }
