using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public Type energyType;
    public string energyName = "기본";

    protected PlayerController player;
    protected bool isEnabled = false;



    protected virtual void Start()
    {
        energyType = Type.Electric;
        player = GameManager.Instance.player;
    }

    protected virtual void Update()
    {

    }

    public virtual void OnEnableEnergy()
    {
        isEnabled = true;
    }

    public virtual void OnDisableEnergy()
    {
        isEnabled = false;
    }

    protected void OnCollisionEnter(Collision _col)
    {
        /*
		if (_col.gameObject.tag == "PlayerFoot")
		{
			if (player.energy != null)
				player.energy.OnDisableEnergy();
			OnEnableEnergy();
			player.energy = this;
		}
		*/
    }

    public enum Type
    {
        Electric,
        Light,
        Kinetic,
        Location,
        Heat,
        Chemical,
    }

    protected void SetMaterial(Material _mat)
    {
        MeshRenderer[] rens = this.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < rens.Length; ++i)
        {
            if (!(rens[i].gameObject.CompareTag("NotChangeRender")))
                rens[i].material = _mat;
        }
    }
}

/*

위치 - 텔레포트 (현재 위치의 위에서 가장 가까운것)
	*/
