using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public GameObject agentPrefab;
    public Transform target;
    public DNA[] population;
    public int popSize;
    int count = 0;
    public int lifeTime;

    private void Start()
    {
        createPopulation();
    }

    void createPopulation()
    {
        population = new DNA[popSize];
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = new DNA(target, Instantiate(agentPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>(), lifeTime);
        }
    }

    private void Update()
    {
        count++;
        for (int i = 0; i < population.Length; i++)
        {
            if (count < population[i]?.genes.Length)
            {
                population[i].rb.AddForce(population[i].genes[count], ForceMode2D.Impulse);
                population[i].Evaluate();
            }
        }

        if (count < lifeTime - 1) return;
        List<DNA> matingPool = new();

        for (int i = 0; i < population.Length; i++)
        {
            int n = Mathf.Max(1, (int)(population[i].fitness * 100));
            for (int j = 0; j < n; j++)
            {
                matingPool.Add(population[i]);
            }
        }

        for (int i = 0; i < population.Length; i++)
        {
            Destroy(population[i]?.rb.gameObject);

            DNA a = matingPool[Random.Range(0, matingPool.Count)];
            DNA b = matingPool[Random.Range(0, matingPool.Count)];
            DNA child = a.Crossover(b);
            child.Mutate();

            child.rb = Instantiate(agentPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            population[i] = child;
        }

        count = 0; 
    }
}
