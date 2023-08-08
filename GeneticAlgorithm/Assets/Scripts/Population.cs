using System.Collections.Generic;
using UnityEngine;


public class Population : MonoBehaviour
{
    Dot[] population;
    public int popBrainSize;
    public GameObject dotPrefab;
    public Transform target;
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
        int fittest = 0;
        Dot fittestDot = null;
        foreach (Dot dot in population)
        {
            currentDeadAgents += dot.brain.DEAD ? 1 : 0;
            if(dot.brain.fitness > fittest)
            {
                fittest = dot.brain.fitness;
                fittestDot = dot;
            }
        }
        if(currentDeadAgents == popSize)
        {
            Debug.Log(fittestDot.brain.fitness);
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
            population[i].brain = new Brain(popBrainSize, population[i].transform, target);
        }
    }
}