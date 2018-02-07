using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int health;

    public static int numWool;
    public static int numFlowers;
    public static int numCatnip;
    public static int numGrapes;

    void Start () {
        health = 3;

        numWool = 0;
        numFlowers = 0;
        numCatnip = 0;
        numGrapes = 0;
	}
	
	void Update () {
		
	}
}
