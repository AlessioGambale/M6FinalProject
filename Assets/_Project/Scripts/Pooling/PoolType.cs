using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    SPLASH ,
    WATERBULLET , 
    STUNBULLET , 
    ARMCHAIR , 
    BARCHAIR , 
    BARTABLE ,
    BED ,
    CHAIR ,
    DOOR , 
    FRIDGE , 
    POT , 
    STAND ,

    NONE = 100
}

[System.Serializable]
public class PoolEntry
{
    public PoolType PoolType;
    public ObjectPool Pool;
}
