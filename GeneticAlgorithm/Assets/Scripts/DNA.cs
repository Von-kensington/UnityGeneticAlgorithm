using System.Collections;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public Vector2[] genes;

    public Transform target;

    public bool dead;

    Rigidbody2D rb;

    public float fitness;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        genes = new Vector2[5];
        for (int i = 0; i < genes.Length; i++) genes[i] = Random.insideUnitCircle;
        InvokeRepeating(nameof(UpdateVelocity), 0, 3);
    }

    public void Evaluate()
    {
        fitness = 1 - (Vector2.Distance(target.position, transform.position) / 10);
    }

    int i = 0;
    void UpdateVelocity()
    {
        if (i == genes.Length - 2) { dead = true; CancelInvoke(); }
        i++;
        rb.velocity = genes[i];
    }

    public DNA Crossover(DNA a, GameObject prefab, Transform spawn)
    {
        GameObject g = Instantiate(prefab, spawn.position, Quaternion.identity);
        g.AddComponent<DNA>();
        DNA child = g.GetComponent<DNA>();
        child.target = target;


        int midpoint = new System.Random().Next(genes.Length-1);
        for(int i = 0; i < genes.Length-1; i++)
        {
            if(i>midpoint) child.genes[i] = a.genes[i];
            else child.genes[i] = genes[i];
        }
        return child;
    }

    public void Mutate()
    {

    }
}