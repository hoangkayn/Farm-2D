using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : BaseMono
{
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEven();
    }
    protected virtual void AddOnClickEven()
    {
        button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
