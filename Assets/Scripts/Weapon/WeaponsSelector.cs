using System.Collections.Generic;
using UnityEngine;

public class WeaponsSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> indexWeapon = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ChangeWeapon(3);
        }
    }
    
    public void ChangeWeapon(int index)
    {
        for (int i = 0; i < indexWeapon.Count; i++)
        {
            indexWeapon[i].SetActive(false);
        }
        indexWeapon[index].SetActive(true);
    }
}
