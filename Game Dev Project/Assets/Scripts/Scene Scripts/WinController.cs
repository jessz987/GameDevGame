using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour {

    public GameObject wool;
    public GameObject catnip;
    public GameObject flower;
    public GameObject grape;

    int numberWool;
    int numberCatnip;
    int numberFlower;
    int numberGrape;

    float timer = 0.5f;
    float currentWoolTimer;
    float currentCatnipTimer;
    float currentGrapeTimer;
    float currentFlowerTimer;

    public ParticleSystem woolParticle;
    public ParticleSystem catnipParticle;
    public ParticleSystem flowerParticle;
    public ParticleSystem grapeParticle;

    private void Start()
    {
        numberWool = GameManager.numWool + GameManager.numYarn * 10;
        Debug.Log("you retrieved " + numberWool + " wool");
        
        //woolParticle.Emit(numberWool);
                
        numberCatnip = GameManager.numCatnip + GameManager.numWine * 15;
        Debug.Log("you retrieved " + numberCatnip + " catnip");

        //catnipParticle.Emit(numberCatnip);

        numberGrape = GameManager.numGrapes + GameManager.numWine * 15;
        Debug.Log("you retrieved " + numberGrape + " grapes");

        //grapeParticle.Emit(numberGrape);


        numberFlower = GameManager.numFlowers + GameManager.numBouquet * 20;
        Debug.Log("you retrieved " + numberFlower + " flowers");

        //flowerParticle.Emit(numberFlower);
       
    }
}
