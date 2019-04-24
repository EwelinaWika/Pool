using System.Collections;
using UnityEngine;


public class BallInstantiator : MonoBehaviour
{
    public GameObject ballprefab;
    public int balls = 10;
    public float waitTime = 0.5f;
    public float force = 10;

    private void Start()
    {
        StartCoroutine(InstantiateBall());
    }

    IEnumerator InstantiateBall()
    {
        for (int i = 0; i < balls; i++)
        {
            var ball = Instantiate(ballprefab, transform.position, Quaternion.identity);
            var rigid = ball.GetComponent<Rigidbody>();
            rigid.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f)) * Random.Range(1, force), ForceMode.Acceleration);
            yield return new WaitForSeconds(waitTime);
        }
    }
}