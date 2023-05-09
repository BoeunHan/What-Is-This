using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Utility
{
    private static ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    static Utility()
    {
        raycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
    }

    //screenPosition ��ġ�� ���� �߻�
    // pose ������ hits�� ����
    //�浹���� ��ü == TrackableType.All
    public static bool Raycast(Vector2 screenPosition, out Pose pose)
    {
        //raycastmanager�� ���� �߻� �� �浹����
        if (raycastManager.Raycast(screenPosition, hits, TrackableType.All))
        {
            //ù��° hits�� ��ġ ȸ�������� ���η� ������!!
            pose = hits[0].pose;
            return true;
        }
        else
        {
            pose = Pose.identity;
            return false;
        }
    }

    public static bool TryGetInputPosition(out Vector2 position)
    {
        position = Vector2.zero;
        //��ġ���ϸ�
        if (Input.touchCount == 0)
        {
            return false;
        }

        //��ġ�ϸ�
        position = Input.GetTouch(0).position;

        if (Input.GetTouch(0).phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}
