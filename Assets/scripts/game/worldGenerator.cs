using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class worldGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public int distance;
    public int space;
    public int seed;

    public GameObject Grass;
    public GameObject Dirt;
    public GameObject Stone;

    public float heightpoint;
    public float heightpoint2;
    private ArrayList chunks = new ArrayList();

 
        void Awake()
        {
            generateChunk();
        }

        void generateChunk()
        {

            Random.InitState(seed);
            distance = height;
            for (int w = 0; w < width; w++)
            {
                int lowernum = distance - 1;
                int heighernum = distance + 2;


                distance = Random.Range(lowernum, heighernum);
                space = Random.Range(1, 8);
                int stonespace = distance - space;


                for (int j = 0; j < stonespace; j++)
                {
                  Instantiate(Stone, new Vector3(w, j), Quaternion.identity);
                }

                for (int j = stonespace; j < distance; j++)
                {
  
                    Instantiate(Dirt, new Vector3(w, j), Quaternion.identity);
                }

                Instantiate(Grass, new Vector3(w, distance), Quaternion.identity);
            }
        }

        void loadChunk()
        {

        }

        void Update()
        {

        }
    
}
