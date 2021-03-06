using UnityEngine;
using System.Collections;

public class ViewLeftBtn : UIBtn  {
	

	public float lookRadians = 1f;
	public float decayRate = 1f;

	protected BeamMain _main = null;	

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();		
		_main = BeamMain.GetInstance();
	}
		
	protected override void Update()
	{
		base.Update();
		if (Input.GetKeyDown(KeyCode.Z ))
			_main.inputDispatch.LookAround(lookRadians, decayRate);
	}

	public override void doSelect()
	{
		_main.inputDispatch.LookAround(lookRadians, decayRate);		
	}
}

