using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SwipeManager))]
public class InputController : MonoBehaviour
{

    Player player;

    void Start()
    {
        

        SwipeManager swipeManager = GetComponent<SwipeManager>();
        swipeManager.onSwipe += HandleSwipe;
        swipeManager.onLongPress += HandleLongPress;
    }

    void HandleSwipe(SwipeAction swipeAction)
    {
        

        Debug.LogFormat("HandleSwipe: {0}", swipeAction);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        else if (swipeAction.direction == SwipeDirection.UpRight || swipeAction.direction == SwipeDirection.DownLeft)
        {
            player.currentState = BLOCKSTATES.BLOCKLEFT;

        }
        else if (swipeAction.direction == SwipeDirection.Right || swipeAction.direction == SwipeDirection.Left)
        {
            player.currentState = BLOCKSTATES.BLOCKHIGH;
        }
        else if (swipeAction.direction == SwipeDirection.DownRight || swipeAction.direction == SwipeDirection.UpLeft)
        {
            player.currentState = BLOCKSTATES.BLOCKRIGHT;
        }
        else
        {
            player.currentState = BLOCKSTATES.NOBLOCK;
        }
        Debug.LogFormat("Block: {0}", player.currentState);
    }

    void HandleLongPress(SwipeAction swipeAction)
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        EventManager.PlayerTap(player.gameObject, new PlayerEventArgs(player));

        Debug.LogFormat("HandleLongPress: {0}", swipeAction);
    }

    
}