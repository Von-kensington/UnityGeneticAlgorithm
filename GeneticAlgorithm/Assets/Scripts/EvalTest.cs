using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EvalTest : MonoBehaviour
    {

        [SerializeField] Transform target;

        // Update is called once per frame
        void Update()
        {
            print((1 / Vector2.Distance(transform.position, target.position))*100);
        }
    }
}