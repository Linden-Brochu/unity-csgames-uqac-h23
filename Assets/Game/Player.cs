using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;

    [SerializeField]
    private int weaponIndex = 0;
    
    [SerializeField]
    private TextMeshProUGUI text;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[weaponIndex].gameObject.SetActive(false);
            weapons[weaponIndex].UnSelect();
            weaponIndex = 0;
            weapons[weaponIndex].gameObject.SetActive(true);
            weapons[weaponIndex].Select();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[weaponIndex].gameObject.SetActive(false);
            weapons[weaponIndex].UnSelect();
            weaponIndex = 1;
            weapons[weaponIndex].gameObject.SetActive(true);
            weapons[weaponIndex].Select();
        }
        
        
        
        text.text = weapons[weaponIndex].GetBullet.ToString();
    }
}
