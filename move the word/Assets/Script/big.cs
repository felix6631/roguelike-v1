
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Script;

public class big : MonoBehaviour
{
    [SerializeField]

    public Map map;

    public GameObject[] Word1Prefaps;
    public GameObject[] Word2Prefaps;
    public GameObject[] Block1Prefaps;
    public GameObject[] Block2Prefaps;
    public big()
    {
        map = new Map();
        Word1Prefaps = new GameObject[4];
        Word2Prefaps = new GameObject[4];
        Block1Prefaps = new GameObject[4];
        Block2Prefaps = new GameObject[4];
    }

    public void Awake()
    {
        var NewMap = map.Generate();
        var rand = new System.Random();

        int sum;
        sum = 0;
        for (int i = 0; i < Map.Width; i++)
        {
            if (i % 2 == 0)
            {
                sum = 0;
            }
            else
            {
                sum = 1;
            }
            for (int j = 0; j < Map.Height; j++)
            {
                if (sum == 0)
                {
                    Instantiate(Word2Prefaps[rand.Next(0, 4)], new Vector3(i, j, 1), Quaternion.identity);
                    sum = 1;
                }
                else if (sum == 1)
                {
                    Instantiate(Word1Prefaps[rand.Next(0, 4)], new Vector3(i, j, 1), Quaternion.identity);
                    sum = 0;
                }
            }
        }


        for (int i = 0; i < Map.Width; i++)
        {
            for (int j = 0; j < Map.Height; j++)
            {
                if (NewMap[i, j] == 1)
                {
                    Instantiate(Block1Prefaps[rand.Next(0, 4)], new Vector3(i, j, 0), Quaternion.identity);/*
                    if (j >= 4 && j+4<=Map.Height)
                    {
                        Instantiate(Word2Prefaps[rand.Next(0, 4)], new Vector3(i, j - 1, 1), Quaternion.identity);
                        Instantiate(Word2Prefaps[rand.Next(0, 4)], new Vector3(i, j - 2, 1), Quaternion.identity);
                        Instantiate(Word2Prefaps[rand.Next(0, 4)], new Vector3(i, j - 3, 1), Quaternion.identity);
                        Instantiate(Word2Prefaps[rand.Next(0, 4)], new Vector3(i, j - 4, 1), Quaternion.identity);
                    }*/
                    if (j > 0)
                        if (NewMap[i, j-1] != 1)
                            Instantiate(Block2Prefaps[rand.Next(0, 4)], new Vector3(i, j-1, 0), Quaternion.identity);
                }
            }
        }



        for (int i = 0; i <=Map.Width; i++)
        {
            Instantiate(Block2Prefaps[rand.Next(0, 4)], new Vector3(i, -1, 0), Quaternion.identity);
            Instantiate(Block2Prefaps[rand.Next(0, 4)], new Vector3(i, Map.Width - 1, 0), Quaternion.identity); 

            Instantiate(Block1Prefaps[rand.Next(0, 4)], new Vector3(0, i, 0), Quaternion.identity);
            Instantiate(Block1Prefaps[rand.Next(0, 4)], new Vector3(i, 0, 0), Quaternion.identity);


            Instantiate(Block1Prefaps[rand.Next(0, 4)], new Vector3(Map.Width, i, 0), Quaternion.identity);
            Instantiate(Block1Prefaps[rand.Next(0, 4)], new Vector3(i, Map.Width, 0), Quaternion.identity);

        }
    }
}



