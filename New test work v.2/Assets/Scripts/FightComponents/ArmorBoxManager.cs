using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBoxManager : MonoBehaviour
{
    public GameObject armorPrefub;
    public List<GameObject> armorBoxsPoimts;

    void Start()
    {
        StartArmorPosition();
        EventAggregator.Subscribe<Armor>(OnArmorBoxesEvent);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<Armor>(OnArmorBoxesEvent);
    }

    void Update()
    {
        
    }

    private void StartArmorPosition()
    {
        StartCoroutine(InstFirstArmorBoxPosition());
    }

    private void OnArmorBoxesEvent(object sender, Armor heal)
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(InstArmorBoxAfterPause());
    }

    private IEnumerator InstFirstArmorBoxPosition()
    {
        yield return new WaitForSeconds(25);
        InstArmoringBox();

    }

    private IEnumerator InstArmorBoxAfterPause()
    {
        yield return new WaitForSeconds(25);
        InstArmoringBox();

    }

    private void InstArmoringBox()
    {
        var curPointIndex = Random.Range(0, armorBoxsPoimts.Count);
        Instantiate(armorPrefub, armorBoxsPoimts[curPointIndex].transform.position, Quaternion.identity);
    }
}
