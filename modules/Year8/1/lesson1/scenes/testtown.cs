function testtown::onAdd(%this)
{
}

function testtown::setup(%this)
{
   %this.setName("testtown");

   //	Add Tiled Map
   %mapSprite = new TmxMapSprite()
   {
      Map = "Year8:testtown_map";
   };
	
	%this.add(%mapSprite);
	
	%layer = 13;
   
   %this.setupCharacters(%layer);
   %this.setupItems(%layer);
   
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
   %label = createCustomLabel("ADD CHARACTER DIALOG");
   DialogueBox.addGuiControl(%label);
   
	GlobalActionMap.bind( keyboard, "w",  createDialogueBox);   // Press 'enter' to open dialogBox
}

function createDialogueBox()
{
   echo("Some Text");
    // Is the console awake?
    if ( DialogueBox.isAwake() )
    {
        Canvas.popDialog(DialogueBox);    
        //Canvas.popDialog($label);   
        return;
    }
    
    Canvas.pushDialog(DialogueBox);
    //Canvas.pushDialog($label);
}

function testtown::setupCharacters(%this, %layer)
{
   //  Create Player
   %position = PlayerPosition.Position;
   SetupPlayer(%this, %position, %layer);
   
   //  Barbarian
   %barbarian = new CompositeSprite(Barbarian)
   {
      displayName = "Barbarian";
      class = "Character";
      imageName = "Assets:TD_Barbarian_";  // temporary
      Position = BarbarianPosition.Position;
      SceneLayer = %layer;
   };
   //Character.setup(%barbarian);
   
   //  Dwarf
   %dwarf = new CompositeSprite(Dwarf)
   {
      displayName = "Dwarf";
      class = "Character";
      imageName = "Assets:TD_Dwarf";  // temporary
      Position = DwarfPosition.Position;
      SceneLayer = %layer;
   };
   
   //  Knight
   %knight = new CompositeSprite(Knight)
   {
      displayName = "Knight";
      class = "Character";
      imageName = "Assets:TD_Knight_";  // temporary
      Position = KnightPosition.Position;
      SceneLayer = %layer;
   };

   // Add to Scene
   //GameScene.add(Player);
   %this.add(%barbarian);
   %this.add(%dwarf);
   %this.add(%knight);
}

function testtown::setupItems(%this, %layer)
{
   //  Red Gem
   %gemRed = new Sprite(RedGem)
   {
      displayName = "Red Gem";
      class = "Item";
      Position = RedGemPosition.Position;
      SceneLayer = %layer;
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      displayName = "Blue Gem";
      class = "Item";
      Position = BlueGemPosition.Position;
      SceneLayer = %layer;
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      displayName = "Green Gem";
      class = "Item";
      Position = GreenGemPosition.Position;
      SceneLayer = %layer;
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

function testtown::setupTriggers(%this)
{
	//	Should already be created via Tiled
	ToGardenNorth.class = "Transition";
	ToGardenNorth.toScene = "garden";
	
	ToGardenSouth.class = "Transition";
	ToGardenSouth.toScene = "testart";
}

//	Triggers
function ToGardenNorthWarn::onEnter(%this, %object)
{
	echo("About to enter Garden");
}
function ToGardenNorthWarn::onStay(%this, %object)
{
	echo(%this.getPosition());
	echo(%object.getPosition());
}

function ToGardenSouthWarn::onEnter(%this, %object)
{
	echo("About to enter Test Art");
}
function ToGardenSouthWarn::onStay(%this, %object)
{
	echo(%this.getPosition());
	echo(%object.getPosition());
}

function RandomCircle::onStay(%this, %object)
{
	echo(%this.getPosition());
	echo(%object.getPosition());
}

/*
function ToGardenNorthWarn::onAddToScene(%this)
{
	echo("ToGardenNorthWarn");
	%this.setClass("TriggerBox");
}
function ToGardenSouthWarn::onAddToScene(%this)
{
	echo("ToGardenSouthWarn");
	%this.setClass("TriggerBox");
}
function RandomCircle::onAddToScene(%this)
{
	echo("RandomCircle");
	%this.setClass("TriggerCircle");
}*/