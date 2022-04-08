using System;
using UnityEngine;

public class Init : MonoBehaviour {
   public GameObject prefab;
   public GameObject player;
   public PlayerSprite[] t1sprites;
   public PlayerSprite[] t2sprites;

   async void Start()
   {
       for (int x = 0; x < 10; x++) {
           for (int z = 0; z < 10; z++) {
               Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
           }
       }

       t1sprites = new PlayerSprite[4];
       t2sprites = new PlayerSprite[4];

       for (int i = 0; i < t1sprites.Length; i++) {
               t1sprites[i] = PlayerSprite.inst(i / 2, (float)0.9, 0);
       }

        for (int i = 0; i < t2sprites.Length; i++) {
               t1sprites[i] = PlayerSprite.inst(i / 2, (float)0.9, 0);
       }

        // for (int i = 0, x = 0; i < p.Length && x <= 8; i++, x += 2) {
        //         p[i] = new Player(x, 1, 0);
        //         Instantiate(player, p[i].vector, Quaternion.identity);
        // }
        
   }
    private async void Update() {
        // if (Input.GetKeyDown(KeyCode.W)) {
        //         p[2].vector.Set(p[2].vector.x, p[2].vector.y, p[2].vector.z + 1);
        //         Destroy(p[2]);
                
        //     }


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