using UnityEngine;

public interface IFactory
{
    GameObject FactoryMethod(Transform[] spawnPoints, int tag);
}