using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public float speed = 2f;

    float t;

    void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(A.position, B.position, Mathf.PingPong(t, 1));
    }
}