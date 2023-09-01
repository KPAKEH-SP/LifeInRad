using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Animator _animator;

    public void GenerateDescription(List<string> variants)
    {
        _animator.Play("Update");
        _descriptionText.text = variants[Random.Range(0, variants.Count)];
    }
}
