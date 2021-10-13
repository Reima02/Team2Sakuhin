using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItemScript : MonoBehaviour
{
    GameObject playerObj;
    GameObject weaponUI;
    [SerializeField] Library.BulletTypes BulletTypes;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
        weaponUI = GameObject.Find("WeaponUI");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                playerObj.GetComponent<PlayerController>().ChengWeapon(BulletTypes);
                weaponUI.GetComponent<WeaponUIScript>().ChengeWeaponUI(BulletTypes);
            }
        }
    }
}
