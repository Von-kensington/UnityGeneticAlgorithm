using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlaceObstacles : MonoBehaviour
    {

        public GameObject obstacle, target;


        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(obstacle, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, Quaternion.identity);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            }
        }
    }
}