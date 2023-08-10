using System.Collections;
using UnityEngine;

public class DNA
{
    public Vector2[] genes;
    public Transform target;
    public Rigidbody2D rb;
    public bool dead;
    public float fitness;
    readonly int brainSize;

    public DNA(Transform target, Rigidbody2D rb, int brainSize)
    {
        this.target = target;
        this.rb = rb;
        this.brainSize = brainSize;
        genes = new Vector2[brainSize];
        for (int i = 0; i < genes.Length; i++)
        {
            genes[i] = Random.insideUnitCircle;
        }
    }

    public void Evaluate()
    {
        float dist = Vector2.Distance(rb.transform.position, target.position);
        fitness = 1 / dist;
        if (dist < 4)
        {
            fitness *= 10;
        }
    }

    public DNA Crossover(DNA a)
    {
        DNA child = new DNA(target, null, brainSize);
        int midpoint = Random.Range(0, genes.Length);
        for (int i = 0; i < genes.Length; i++)
        {
            child.genes[i] = i < midpoint ? genes[i] : a.genes[i];
        }

        return child;
    }

    public void Mutate()
    {
        for (int i = 0; i < genes.Length; i++)
        {
            if (Random.value < 0.01f)
            {
                genes[i] = Random.insideUnitCircle * (Random.value);
            }
        }
    }
}
