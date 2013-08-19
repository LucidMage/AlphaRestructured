function testart::onAdd(%this)
{
}

function testart::setup(%this)
{
   %this.setName("testart");

   //	Add Tiled Map
   %mapSprite = new TmxMapSprite()
   {
      Map = "Year8:testart_map";
   };
	
	%this.add(%mapSprite);
   
   %this.setupCharacters();
   %this.setupItems();
   
	%pushable = new Sprite()
	{
		class = Pushable;
		Image = "Assets:Tiles";
		Position = "-1 -2";
		SceneLayer = %layer;
	};
	%this.add(%pushable);
   
   %this.setupTriggers();
   
   //	Create GUI stuff here for now
   %label = createCustomLabel("ADD CHARACTER DIALOGUE");
   Dialogue.addGuiControl(%label);
   
	GlobalActionMap.bind( keyboard, "enter",  createDialogueBox);   // Press 'enter' to open dialogBox
}

function createDialogueBox()
{
    // Is the console awake?
    if ( Dialogue.isAwake() )
    {
        Canvas.popDialog(Dialogue);    
        //Canvas.popDialog($label);   
        return;
    }
    
    Canvas.pushDialog(Dialogue);
    //Canvas.pushDialog($label);
}

function testart::setupCharacters(%this)
{
   //  Create Player
   echo("Player Setup");
   SetupPlayer(%this, PlayerPos.getPosition(), PlayerPos.getSceneLayer());
   echo("End of Player Setup");
   
   //  Dragon
   %dragon = new Sprite(Dragon)
   {
      displayName = "Dragon";
      class = "Guide";
      imageName = "Assets:Dragon";  // temporary
      Position = DragonPos.getPosition();
      SceneLayer = DragonPos.getSceneLayer();
   };
   
   //  Fairy
   %fairy = new Sprite(Fairy)
   {
      displayName = "Fairy";
      class = "Guide";
      imageName = "Assets:Fairy";  // temporary
      Position = FairyPos.getPosition();
      SceneLayer = FairyPos.getSceneLayer();
   };
   
   //  Kea
   %kea = new Sprite(Kea)
   {
      displayName = "Kea";
      class = "Guide";
      imageName = "Assets:Kea";  // temporary
      Position = KeaPos.getPosition();
      SceneLayer = KeaPos.getSceneLayer();
   };
   
   //  Owl
   %owl = new Sprite(Owl)
   {
      displayName = "Owl";
      class = "Guide";
      imageName = "Assets:Owl";  // temporary
      Position = OwlPos.getPosition();
      SceneLayer = OwlPos.getSceneLayer();
   };

   // Add to Scene
   %this.add(%dragon);
   %this.add(%fairy);
   %this.add(%kea);
   %this.add(%owl);
}

function testart::setupItems(%this)
{
   //  Red Gem
   %gemRed = new Sprite(RedGem)
   {
      displayName = "Red Gem";
      class = "Item";
      Position = RedGemPos.getPosition();
      SceneLayer = RedGemPos.getSceneLayer();
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      displayName = "Blue Gem";
      class = "Item";
      Position = BlueGemPos.getPosition();
      SceneLayer = BlueGemPos.getSceneLayer();
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      displayName = "Green Gem";
      class = "Item";
      Position = GreenGemPos.getPosition();
      SceneLayer = GreenGemPos.getSceneLayer();
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

function testart::setupTriggers(%this)
{
	echo("Setup Triggers");
	
	SetupTrigger(ToTestTown);
	SetupTrigger(ToTestTownWarn);

	//	Should already be created via Tiled
	ToTestTown.toScene = "testtown";
}

//	Triggers
function ToTestTown::onEnter(%this, %object)
{
	HelpText.Text = "Transferring to Test Town";
}

function ToTestTownWarn::onEnter(%this, %object)
{
	HelpText.Text = "About to enter Test Town";
}
function ToTestTownWarn::onStay(%this, %object)
{
	echo(%this.getPosition());
	echo(%object.getPosition());
}