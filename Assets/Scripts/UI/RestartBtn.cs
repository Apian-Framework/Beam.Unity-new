using UnityEngine;
using System.Collections;


public class RestartBtn : UIBtn  {
	
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
		//  Call RaiseRespawnPlayer() which will signal ModeLPlay to do so.
		if (Input.GetKeyDown(KeyCode.Return))
			_main.backend.RaiseRespawnPlayer();
	}

	public override void doSelect()
	{
		_main.backend.RaiseRespawnPlayer();
	}
}

