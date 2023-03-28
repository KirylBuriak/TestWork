using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealingBoxManager : MonoBehaviour
{
    public GameObject healingPrefub;
    public List<GameObject> healigBoxsPoimts;

    
    void Start()
    {
        StartGameHealPosition();
        EventAggregator.Subscribe<Healing>(OnHealingBoxesEvent);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<Healing>(OnHealingBoxesEvent);
    }

    void Update()
    {
        
    }

    private void StartGameHealPosition()
    {
        var curPointIndex = Random.Range(0, healigBoxsPoimts.Count);
        Instantiate(healingPrefub, healigBoxsPoimts[curPointIndex].transform.position, Quaternion.identity);

    }

    private void OnHealingBoxesEvent(object sender, Healing heal)
    {
        StartCoroutine(InstHealingBoxAfterPause());
    }

    private IEnumerator InstHealingBoxAfterPause()
    {
        yield return new WaitForSeconds(5);
        InstHealingBox();

    }

    private void InstHealingBox()
    {
        var curPointIndex = Random.Range(0, healigBoxsPoimts.Count);
        Instantiate(healingPrefub, healigBoxsPoimts[curPointIndex].transform.position, Quaternion.identity);
    }
}
