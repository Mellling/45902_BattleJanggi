using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Po : Piece
{
    [SerializeField] LayerMask cheakSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)
    List<int> CanGoSpots;   // �� �� �ִ� Spot�� ��ġ ����
    private void OnTriggerEnter(Collider other)
    {
        if (cheakSpot.Contain(other.gameObject.layer))
        {
            // gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, gameObject.transform.position.y , other.gameObject.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        // ���� x ��ǥ ���� �� ���� �� �˻�

        for (int x = 0; x < currentPos['x']; x++)
        {

        }

        // ���� x ��ǥ ���� �� ū �� �˻�

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {

        }

        // ���� z ��ǥ ���� �� ���� �� �˻�

        for (int z = 0; z < currentPos['z']; z++)
        {

        }

        // ���� z ��ǥ ���� �� ū �� �˻�

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {

        }
    }
}
