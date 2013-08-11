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
	
	%layer = 13;
   
   %this.setupCharacters(%layer);
   //%this.setupItems(%layer);
   
	%pushable = new Sprite()
	{
		class = Pushable;
		Image = "Assets:Tiles";
		Position = "-1 -2";
		SceneLayer = %layer;
	};
	%this.add(%pushable);
   
   //%this.setupTriggers();
}

function testart::setupCharacters(%this, %layer)
{
   //  Create Player
   %position = PlayerPos.Position;
   SetupPlayer(%this, %position, %layer);
   
   //  Dragon
   %dragon = new Sprite(Dragon)
   {
      displayName = "Dragon";
      class = "Guide";
      imageName = "Assets:Dragon";  // temporary
      Position = DragonPos.Position;
      SceneLayer = %layer;
   };
   //Character.setup(%barbarian);
   
   //  Fairy
   %fairy = new Sprite(Fairy)
   {
      displayName = "Fairy";
      class = "Guide";
      imageName = "Assets:Fairy";  // temporary
      Position = FairyPos.Position;
      SceneLayer = %layer;
   };
   
   //  Kea
   %kea = new Sprite(Kea)
   {
      displayName = "Kea";
      class = "Guide";
      imageName = "Assets:Kea";  // temporary
      Position = KeaPos.Position;
      SceneLayer = %layer;
   };
   
   //  Owl
   %owl = new Sprite(Owl)
   {
      displayName = "Owl";
      class = "Guide";
      imageName = "Assets:Owl";  // temporary
      Position = OwlPos.Position;
      SceneLayer = %layer;
   };

   // Add to Scene
   //GameScene.add(Player);
   %this.add(%dragon);
   %this.add(%fairy);
   %this.add(%kea);
   %this.add(%owl);
}

function testart::setupItems(%this, %layer)
{
   //  Red Gem
   %gemRed = new Sprite(RedGem)
   {
      displayName = "Red Gem";
      class = "Item";
      Position = RedGemPos.Position;
      SceneLayer = %layer;
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      displayName = "Blue Gem";
      class = "Item";
      Position = BlueGemPos.Position;
      SceneLayer = %layer;
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      displayName = "Green Gem";
      class = "Item";
      Position = GreenGemPos.Position;
      SceneLayer = %layer;
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

function testart::setupTriggers(%this)
{
	//	Should already be created via Tiled
	ToTestTown.class = "Transition";
	ToTestTown.toScene = "testtown";
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