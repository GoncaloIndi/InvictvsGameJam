using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DeathMenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Flag;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Flag.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Flag.SetActive(false);
    }

}
