using System.Collections.Generic;
using UnityEngine;


public class Population : MonoBehaviour
{
    Dot[] population;
    public GameObject dotPrefab;

    public int popSize;
    // Use this for initialization
    void Start()
    {
        ResetPopulation();
    }

    private void FixedUpdate()
    {
        if (population.Length == 0 || population == null) return;
        int currentDeadAgents = 0;
        foreach (Dot dot in population)
        {
            currentDeadAgents += dot.DEAD ? 1 : 0;
        }
        if(currentDeadAgents == popSize)
        {
            ResetPopulation();
        }
    }

    void ResetPopulation()
    {
        if(population != null)
        {
            foreach(Dot dot in population)
            {
                Destroy(dot.gameObject);
            }
        }
        population = new Dot[popSize];
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = Instantiate(dotPrefab, transform.position, Quaternion.identity).GetComponent<Dot>();
        }
    }
}