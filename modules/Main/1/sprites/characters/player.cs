function SetupPlayer(%scene, %position, %layer)
{
   /*
   %player = new CompositeSprite(Player)
   {
      displayName = "Test Player";
      class = "Character";
      imageName = "Assets:TD_Wizard_";  // temporary
      
      Position = %position;
      SceneLayer = %layer;
      // Graphics are defined by the sprites added below
      //Animation = "Assets:TD_Wizard_WalkSouth";
      //Image = "Assets:TD_Wizard_CompSprite";
   };
   
   // Must be different than other characters to stop the player from pushing other characters
   %player.setDefaultDensity(0);
   */
   
   echo("Getting character from profile");
   %player = Profile.character;
   echo("Setup in player setup");
   %player.setup();
   
   %player.setPosition(%position);
   %player.setSceneLayer(%layer);

   // Set Behaviours
   %player.setGeneralBehaviours();
   /*%controls = PlayerControlsBehaviour.createInstance();
   %player.addBehavior(%controls);
   
   %controls = InteractBehaviour.createInstance();
   %player.addBehavior(%controls);*/
   
   // Inventory
   //%inventory = new ScriptObject(Inventory);

   // Add to Scene
   %scene.add(%player);
}

function Player::setGeneralBehaviours(%this)
{
	%this.clearBehaviours();

	%controls = PlayerControlsBehaviour.createInstance();
	%this.addBehavior(%controls);

	%controls = InteractBehaviour.createInstance();
	%this.addBehavior(%controls);
}

function Player::setDialogueBehaviours(%this)
{
	%this.clearBehaviours();
	
	%controls = DialogueBehaviour.createInstance();
	%this.addBehaviour(%controls);
}
/*
function Player::onCollision(%this, %sceneobject, %collisiondetails)
{
   //%this.setBodyType(static);
   %this.setLinearVelocity("0 0");
   %this.setAngularVelocity("0");
}*/
/*
function Player::PickUpItem(%this, %item)
{
   %inventory.AddItem(%item);
   Player.inventory[Player.inventoryCount] = %item;
   Player.inventoryCount++;
   
   echo("New Item" SPC %item.getId());
   echo("Item at slot" SPC Player.inventoryCount-- SPC ":" SPC Player.inventory[Player.inventoryCount--]);
   echo("Inventory Count" SPC Player.inventoryCount);
}*/