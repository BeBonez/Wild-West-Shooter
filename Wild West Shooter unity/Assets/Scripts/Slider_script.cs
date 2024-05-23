using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
    public bool isSfx;
    public TMP_Text textoFeedbackValor;
    public Slider slider;
    void Start()
    {
        if (isSfx)
            AtualizarTextoSliderVolumeSFX(Audio_script.Instance.PegarVolumeSFXSalvo());
        else
            AtualizarTextoSliderVolumeBG(Audio_script.Instance.PegarVolumeBGSalvo());
    }
    public void AtualizarTextoSliderVolumeBG(float valor)
    {
        textoFeedbackValor.text = (valor * 100f).ToString("F0") + "%";
        slider.value = valor;
        Audio_script.Instance.AtualizarVolumeBG(valor);
    }

    public void AtualizarTextoSliderVolumeSFX(float valor)
    {
        textoFeedbackValor.text = (valor * 100f).ToString("F0") + "%";
        slider.value = valor;
        Audio_script.Instance.AtualizarVolumeSFX(valor);
    }

}
