using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoc : MonoBehaviour
{
    public Transform[] roomList;
    public Transform currentRoom;
    private void Start()
    {
        currentRoom = roomList[0];
    }

    private void Update()
    {
        transform.position = currentRoom.position;
    }
}
