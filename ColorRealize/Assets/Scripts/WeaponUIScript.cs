using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIScript : MonoBehaviour
{
    [SerializeField] Sprite[] weaponImages;

    public void ChengeWeaponUI(Library.BulletTypes bulletType)
    {
        gameObject.GetComponent<Image>().sprite = weaponImages[(int)bulletType];
    }
}
