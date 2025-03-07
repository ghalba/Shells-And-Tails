﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Guard : MonoBehaviour
{
    public static event System.Action onguardspotedPlayer;

    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;
    public float timetospotplayer = .8f;
    public AudioSource _howl;
    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    float viewAngle;
    float playervisibletimer;

    public Transform pathHolder;
    Transform player;
    Color originalSpotlightColour;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));

    }

    void Update()
    {

        if (CanSeePlayer()) {
            playervisibletimer += Time.deltaTime;
            _howl.Play();

        } else {
            playervisibletimer -= Time.deltaTime;
        }
        playervisibletimer = Mathf.Clamp(playervisibletimer, 0, timetospotplayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playervisibletimer / timetospotplayer);
        if (playervisibletimer >= timetospotplayer) {
            Debug.Log("spotted");
            
            player.GetComponent<Respawn>()._respawn = true;

        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool turningPhase;

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0];
            int targetWaypointIndex = 1;
            if (waypoints.Length > targetWaypointIndex)
            {
                Vector3 targetWaypoint = waypoints[targetWaypointIndex];
                transform.LookAt(targetWaypoint);
                while (true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
                    if (transform.position == targetWaypoint)
                    {
                        turningPhase = true;
                        targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                        targetWaypoint = waypoints[targetWaypointIndex];
                        transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Stop");
                        yield return new WaitForSeconds(waitTime);
                        yield return StartCoroutine(TurnToFace(targetWaypoint));
                    }
                    yield return null;
                }
            }
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
        turningPhase = false;
        transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Walk");
    }

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

}