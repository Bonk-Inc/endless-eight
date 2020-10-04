using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class ConversationPlayer : MonoBehaviour
{
    private List<GameObject> personToTalkTo;
    [SerializeField] PopUpBehaviour popUpBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        personToTalkTo = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && personToTalkTo.Count != 0)
        {

            if (personToTalkTo.Count > 1) findOutWhichPersonToTalkTo();
            else TalkTopeople(personToTalkTo[0]);
        }
    }

    public void TalkTopeople(GameObject personToInteractWith)
    {
        Debug.Log("interaction wtih " + personToInteractWith.name);
        // TODO talk to the person to interact with.
        personToInteractWith.GetComponent<KillablePerson>().Kill();//TODO choose interaction
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("InteractablePerson"))
            personToTalkTo.Add(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag.Equals("InteractablePerson"))
        {
            personToTalkTo.Remove(other.gameObject);
            if (personToTalkTo.Count < 2)
            {
                popUpBehaviour.DisablePopUp();
            }
        }

    }

    private void findOutWhichPersonToTalkTo()
    {
        KillablePerson[] killablePpl = new KillablePerson[10];
        for (int i = 0; i < personToTalkTo.Count; i++)
        {
            killablePpl[i] = personToTalkTo[i].GetComponent<KillablePerson>();
        }
        //TODO UI met plaatjes van alle mensen en vervolgens dan op kunnen laten drukken.

        popUpBehaviour.ShowPopUp(killablePpl);


        Debug.Log("Test");
    }



}
