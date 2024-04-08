using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// ��⸻(��)�� ��������
/// </summary>
public class ChaLazer : Weapon
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LazerGunImpact hitEffect;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] AudioSource sound;

    [SerializeField] Transform hitPoint;

    public override void Fire()
    {
        muzzleFlash.Play();
        sound.Play();

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {

            // ����ĳ��Ʈ ���̰� �ϱ�
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.5f);
            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            // �´� ��ġ�� ���ڱ� ����Ʈ
            Manager.Pool.GetPool(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            //ParticleSystem partcl = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            //partcl.transform.position = hitInfo.point;
            //Destroy(partcl, 1.5f);

            // �¾��� �� ������ ����
            //Rigidbody rigid = hitInfo.collider.GetComponent<Rigidbody>();
            //if (rigid != null)
            //{
            //    rigid.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
            //}

            // �´� �α�
            Debug.Log("�¾Ҵ�!");

            // �������̽��� ã�Ƽ� ������ �ֱ�
            FPSPiece target = hitInfo.collider.GetComponent<FPSPiece>();

            target?.TakeDamage(Damage);

            // ����ĳ��Ʈ ����� ���
            /*
            Debug.Log(hitInfo.collider.gameObject.name);
            Debug.Log(hitInfo.distance);
            hitPoint.position = hitInfo.point;
            */
        }
        else
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1,hitInfo.point + ray.direction * maxDistance);
            Debug.Log("�ȸ¾Ҵ�!");
        }
    }
}
