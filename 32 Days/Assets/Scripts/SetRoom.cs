using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoom : MonoBehaviour
{
    [SerializeField] private RoomLoc loc;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            int room = int.Parse(other.gameObject.tag);
            room--;
            loc.currentRoom = loc.roomList[room];
        }
    }
}
