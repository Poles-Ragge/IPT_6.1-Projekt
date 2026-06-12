using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject weaponSprite;
    public AudioClip shootClip;
    public int ammo = 30;
    public int magazinSize = 30;
    public float reloadTime = 2f;
    private bool isReloading;
    private PlayerMovement player;
    private AudioSource audioSource;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (weaponSprite != null)
        {
            weaponSprite.SetActive(player.hasGewehr);
        }

        if (!player.hasGewehr)
        {
            return;
        }

        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (ammo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        GW_Bullet bulletScript = bullet.GetComponent<GW_Bullet>();
        bulletScript.Fire(direction);

        if (audioSource != null && shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }

        ammo--;
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammo = magazinSize;
        isReloading = false;
    }
}