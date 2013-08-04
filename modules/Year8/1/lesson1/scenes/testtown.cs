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
}

function testtown::setupCharacters(%this, %layer)
{
   //  Create Player
   %position = PlayerPosition.Position;
   SetupPlayer(%this, %position, %layer);
   
   //  Barbarian
   //%this.add(BarbarianPosition);
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
   %toGardenNorth = new Trigger()
   {
      class = "Transition";
      height = 1;
      width = 4;
      
      Position = "2.5 9";
      //Position = ToGardenNorthPosition.Position;
      toScene = "garden";
   };

   //  Add to Scene
   %this.add(%toGardenNorth);
}
/*
//	Triggers
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