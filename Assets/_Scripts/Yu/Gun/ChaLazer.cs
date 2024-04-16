using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ������ : ChanGyu
/// ��⸻(��)�� ��������
/// </summary>
public class ChaLazer : Weapon
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LazerGunImpact hitEffect;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] AudioSource sound;

    [SerializeField] Transform hitPoint;

    float rate = 1.5f;     // ����ӵ�
    bool isfire;
    bool isReloading;

    protected override void Start()
    {
        base.Start();
        isfire = true;
        isReloading = false;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    public override void Fire()
    {
        if (curMagazine > 0)
        {
            if (!isfire)
                return;

            muzzleFlash.Play();
            sound.Play();

            curMagazine--;

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

                // Player�� ã�Ƽ� ������ �ֱ�
                FPSPiece target = hitInfo.collider.GetComponent<FPSPiece>();
                target?.TakeDamage(Damage);
            }
            else
            {
                Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
                lineRenderer.gameObject.SetActive(true);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hitInfo.point + ray.direction * maxDistance);
            }
            StartCoroutine(CalRate());
        }
        else
        {

            if (isReloading)
                return;

            isReloading = true;
            StartCoroutine(Reload());
        }
    }

    IEnumerator CalRate()
    {
        isfire = false;
        yield return new WaitForSeconds(rate);
        isfire = true;
    }

    IEnumerator Reload()
    {
        isfire = false;
        yield return new WaitForSeconds(1f);
        isfire = true;
        isReloading = false;
        curMagazine = maxMagazine;
    }
}
