using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Script;

public class big : MonoBehaviour
{
    [SerializeField]
    public GameObject BlockPrefap;
    public GameObject Word1Prefap;
    public GameObject Word2Prefap;
    public GameObject Word3Prefap;
    public GameObject Word4Prefap;

    public Map map;

    public big()
    {
        map = new Map();
    }

    public void Awake()
    {   
        var NewMap = map.Generate();
        var rand = new  System.Random();
        
        for (int i = 0; i < Map.Width; i++)
        {
            for (int j = 0; j < Map.Height; j++)
            {
                /*
                if (rand.Next(1, 4) == 1) Instantiate(Word1Prefap, new Vector3(i, j,0), Quaternion.identity);
                else if (rand.Next(1, 4) == 2) Instantiate(Word2Prefap, new Vector3(i, j,0), Quaternion.identity);
                else if (rand.Next(1, 4) == 3) Instantiate(Word3Prefap, new Vector3(i, j,0), Quaternion.identity);
                else Instantiate(BlockPrefap, new Vector3(i, j,0), Quaternion.identity);*/
                Instantiate(BlockPrefap, new Vector3(i, j, 0), Quaternion.identity);
                if (NewMap[i, j] == '#')
                    Instantiate(Word1Prefap, new Vector3(i, j,-1), Quaternion.identity);
            }
        }
        for (int i = 0; i < Map.Width+1; i++)
        {
            Instantiate(Word1Prefap, new Vector3(0, i,-1), Quaternion.identity);
            Instantiate(Word1Prefap, new Vector3(i, 0,-1), Quaternion.identity);
            Instantiate(Word1Prefap, new Vector3(Map.Width, i,-1), Quaternion.identity);
            Instantiate(Word1Prefap, new Vector3(i, Map.Width,-1), Quaternion.identity);
        }
    }
}
