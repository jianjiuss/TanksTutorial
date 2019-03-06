using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    private Camera camera;

    public Transform player1;
    public Transform player2;

    public GameObject testSphere;
    
    private Vector3 midPointBetweenPlayer;
    private Vector3 offsetBetweenMidPointAndCamera;
    private float offsetBetweenDisAndSize;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Start()
    {
        float distanceBetweenPlayer = (player1.position - player2.position).magnitude;
        offsetBetweenDisAndSize = distanceBetweenPlayer / camera.orthographicSize;

        midPointBetweenPlayer = (player1.position + player2.position) / 2;
        
        Vector3 p1 = camera.WorldToViewportPoint(midPointBetweenPlayer);
        Vector3 pointA = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, p1.z));
        Vector3 offset = midPointBetweenPlayer - pointA;
        transform.SetPositionAndRotation(transform.position + offset, transform.rotation);

        offsetBetweenMidPointAndCamera = transform.position - midPointBetweenPlayer;
    }

    void Update()
    {
        midPointBetweenPlayer = (player1.position + player2.position) / 2;
        testSphere.transform.SetPositionAndRotation(midPointBetweenPlayer, Quaternion.identity);
        Vector3 curCameraPoint = midPointBetweenPlayer + offsetBetweenMidPointAndCamera;
        transform.SetPositionAndRotation(curCameraPoint, transform.rotation);

        float distanceBetweenPlayer = (player1.position - player2.position).magnitude;
        camera.orthographicSize = Mathf.Clamp(distanceBetweenPlayer / offsetBetweenDisAndSize, 8f, 20f);
    }


}
