using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Population : MonoBehaviour
{
    public GameObject agentPrefab;
    public Transform target;
    public DNA[] population;
    public int popSize;
    private void Start()
    {
        population = new DNA[popSize];
        for(int i = 0; i <population.Length; i++)
        {
            GameObject g = Instantiate(agentPrefab, transform.position, Quaternion.identity);
            g.AddComponent<DNA>();
            DNA gDNA = g.GetComponent<DNA>();
            gDNA.target = target;
            population[i] = gDNA;
        }
    }

    private void Update()
    {
        if (!PopulationDead()) return;

        Selection();

        PopulateMatingPool();

    }

    bool PopulationDead()
    {
        int nDeadDna = 0;

        for(int i = 0; i<population.Length; i++)
        {
            nDeadDna += population[i].dead ? 1 : 0;
        }

        return nDeadDna == population.Length;
    }

    void Selection()
    {
        for (int i = 0; i < population.Length; i++)
        {
            population[i].Evaluate();
        }
    }

    void PopulateMatingPool()
    {
        List<DNA> matingPool = new();

        for (int i = 0; i < population.Length; i++)
        {
            Destroy(population[i].gameObject);
            int n = (int)(population[i].fitness * 100);
            for(int j = 0; j < n; j++)
            {
                matingPool.Add(population[i]);
            }
            int a = new System.Random().Next(matingPool.Count-1);
            int b = new System.Random().Next(matingPool.Count-1);
            DNA partnerA = matingPool[a];
            DNA partnerB = matingPool[b];
            DNA child = partnerA.Crossover(partnerB, agentPrefab, transform);
            population[i] = child;
            //child.Mutate(0.01);
        }
    }
}
