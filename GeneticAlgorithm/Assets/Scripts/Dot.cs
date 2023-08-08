using UnityEngine;

public class Dot : MonoBehaviour
{
    Brain brain;
    public float currentTime;
    Rigidbody2D rb;
    public int directionIndex;
    public bool DEAD = false;
    // Start is called before the first frame update
    void Start()
    {
        brain = new Brain(10);
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTime %= 10;
        if (directionIndex >= brain.directions.Length - 1) DEAD = true;
        if (DEAD)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        directionIndex = (int)currentTime;
        rb.velocity = brain.directions[directionIndex];
    }
}
