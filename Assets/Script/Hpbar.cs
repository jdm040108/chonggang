using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public P_Enemy Owner;
    public Slider slider;
    public Slider effect_slider;

    bool effect = true;

    private void Start()
    {
        Owner.take_damage += EffectON;
        slider.maxValue = Owner.max_hp;
        effect_slider.maxValue = Owner.max_hp;
        effect_slider.value = Owner.max_hp;
    }

    void Update()
    {
        if (Owner)
        {
            slider.value = Mathf.Lerp(slider.value, Owner.hp, Time.deltaTime * 13);
            transform.position = Owner.transform.position + new Vector3(0, 3);

            if (effect)
            {
                effect_slider.value = Mathf.Lerp(effect_slider.value, slider.value, Time.deltaTime * 13);
                if (slider.value >= effect_slider.value - 0.01f)
                {
                    effect = false;
                    effect_slider.value = slider.value;
                }
            }
        }
        else
            Destroy(gameObject);
    }

    IEnumerator CEffectOn()
    {
        yield return new WaitForSeconds(0.5f);
        effect = true;
    }

    public void EffectON()
    {
        StartCoroutine(CEffectOn());
    }
}
