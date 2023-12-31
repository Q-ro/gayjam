using Scripts.Interaction;
using System;
using System.Collections;
using UnityEngine;

public class NPCSpawnerController : MonoBehaviour
{
    //public static Action OnNPCExitedScene;

    [SerializeField] GameObject[] npcsToSpawn;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform tableWapoint;
    [SerializeField] Transform exitWapoint;
    [SerializeField] float spawnDelay;

    GameObject currentNPC;
    int npcToSpawnIndex; //hack

    void Start()
    {
        SpawnNPC();
        FadeInNPC();
        InspectableObject.OnObjectWasInspected += FadeOutNPC;
        DialogObject.OnObjectWasRetrieved += FadeOutNPC;
    }

    private void OnDestroy()
    {
        InspectableObject.OnObjectWasInspected -= FadeOutNPC;
        DialogObject.OnObjectWasRetrieved -= FadeOutNPC;
    }

    private void FadeOutNPC()
    {
        StopAllCoroutines();

        StartCoroutine(COMoveToTarget(exitWapoint.position, 3.5f, () =>
        {
            Debug.Log("Index: " + npcToSpawnIndex);
            Destroy(currentNPC);
            
            if (npcToSpawnIndex == 4){
                Debug.Log("Deleting family photo");
                FamilyPhotoController.OnReturnPolaroid?.Invoke();
            }
            if (npcToSpawnIndex == 7){
                Debug.Log("Changing radio sound");
                RadioAudioController.OnSetRadioStatic?.Invoke();
            }
            if (npcToSpawnIndex >= npcsToSpawn.Length)
                return;

            
                //RadioAudioController.OnSetRadioStatic?.Invoke();
            // if (npcToSpawnIndex > 4)
                
                //BackgroundNoiseAudioController.OnSetSilenceBackgroundNoise?.Invoke();

            StartCoroutine(CODelayedSpawn());
        }));
    }

    private void FadeInNPC()
    {
        StopAllCoroutines();
        StartCoroutine(COMoveToTarget(tableWapoint.position, 3.5f, () => { }));
    }

    IEnumerator COMoveToTarget(Vector3 targetPosition, float speed, Action callback)
    {
        while (Vector3.Distance(currentNPC.transform.position, targetPosition) > 0.2f)  // Adjust tolerance as needed
        {
            currentNPC.transform.position = Vector3.MoveTowards(currentNPC.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        callback?.Invoke();
    }

    IEnumerator CODelayedSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnNPC();
        FadeInNPC();
    }

    private void SpawnNPC()
    {
        if (npcToSpawnIndex >= npcsToSpawn.Length)
            return;
        currentNPC = Instantiate(npcsToSpawn[npcToSpawnIndex]);
        currentNPC.transform.position = spawnPoint.position;
        npcToSpawnIndex++;
    }

}
