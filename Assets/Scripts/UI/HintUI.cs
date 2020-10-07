using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hintText;
    private void Start()
    {
        PossibleTarget target = TargetManagement.Instance.CurrentTarget;
        hintText.text = target.TargetHint.Lines[1].Line;
    }

}
