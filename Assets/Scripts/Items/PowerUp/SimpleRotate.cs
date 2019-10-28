using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime, rotationSpeed, 0);
    }
}
