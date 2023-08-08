using UnityEngine;


public class Population : MonoBehaviour
{
    Dot[] population;
    public GameObject dotPrefab;
    public Transform spawn;
    public int popSize;
    // Use this for initialization
    void Start()
    {
        population = new Dot[popSize];
        for(int i = 0; i < population.Length; i++)
        {
            Instantiate(dotPrefab, spawn.position, Quaternion.identity);
        }
    }
}