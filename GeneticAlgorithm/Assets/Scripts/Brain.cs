using UnityEngine;

[System.Serializable]
public class Brain
{
    public Vector2[] directions;
    Transform body, target;
    public int fitness = 0;
    public bool DEAD;
    public Brain(int size, Transform body, Transform target)
    {
        this.body = body;
        this.target = target;

        directions = new Vector2[size];
        for (int i = 0; i < size; i++)
        {
            directions[i] = Random.insideUnitCircle;
        }
    }

    public void SetDead()
    {
        DEAD = true;
        fitness = Evaluate();
    }

    public int Evaluate()
    {
        int score = 0;
        score = Mathf.RoundToInt(Vector2.Distance(body.position, target.position)*100);
        return score;
    }
}