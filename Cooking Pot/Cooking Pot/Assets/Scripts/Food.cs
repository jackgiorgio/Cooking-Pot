using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Food/Food")]
public class Food : Item {

    public bool cookable;

// basic value
    public float health;
    public float hunger;
    public float sanity;
    public float perish;

//general category
    public float fruit;
    public float egg;
    public float meat;
    public float veggie;
    public float fish;
    public float inedible;

//specific category
    public float banana;
    public float frozen;
    public float limpets;
    public float butterflyWing;
    public float Seaweed;
    public float roastedCoffeeBeans;
    public float dairy;
    public float sweetener;
    public float dragonfruit;
    public float corn;
    public float twigs;
    public float cactusFlower;
    public float frogLegs;
    public float moleWorm;
    public float cactusFresh;
    public float honey;
    public float jellyfish;
    public float monster;
    public float wobster;
    public float butter;
    public float mandrake;
    public float watermelon;
    public float pumpkin;
    public float sharkFin;
    public float eggplant;
    public float roastedBirchnut;
    public float seed;
    public float berries;
    public float drumstick;
    public float lichen;
    public float eel;

//dlc
    public float reignOfGiants;
    public float shipWrecked;

}