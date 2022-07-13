using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //room to room
    [SerializeField]private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    //follow player
    [SerializeField] private Transform player;

    [SerializeField]private float aheadDistance;
    [SerializeField]private float cameraCatchingUpSpeed;
    private float lookAhead;

    private void Update()
    {
        //room
       // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed );

        //follow w kazdej osi
       // transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
        //follow na osi x
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x),Time.deltaTime * cameraCatchingUpSpeed);

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }

}
