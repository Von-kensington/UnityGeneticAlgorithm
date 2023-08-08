using UnityEngine;

public class Dot : MonoBehaviour
{
    public Brain brain;
    public float currentTime;
    Rigidbody2D rb;
    public int directionIndex;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brain == null) return;
        currentTime += Time.deltaTime;
        currentTime %= 10;
        if (directionIndex >= brain.directions.Length - 1) brain.SetDead();
        if (brain.DEAD)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        directionIndex = (int)currentTime;
        rb.velocity = brain.directions[directionIndex];
    }
}
