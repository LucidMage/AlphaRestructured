// Treat this as like a class constructor for the lesson
function testtown::onAdd(%this)
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
   %this.setupTransitions();
}

function testtown::setupCharacters(%this, %layer)
{
   //  Create Player
   createPlayer(%this, "0 -2", %layer);
   
   //  Barbarian
   %barbarian = new CompositeSprite(Barbarian)
   {
      name = "Barbarian";
      class = "Character";
      imageName = "Assets:TD_Barbarian_";  // temporary
      Position = "-2 -2";
      SceneLayer = %layer;
   };
   
   //  Dwarf
   %dwarf = new CompositeSprite(Dwarf)
   {
      name = "Dwarf";
      class = "Character";
      imageName = "Assets:TD_Dwarf";  // temporary
      Position = "-4 -2";
      SceneLayer = %layer;
   };
   
   //  Knight
   %knight = new CompositeSprite(Knight)
   {
      name = "Knight";
      class = "Character";
      imageName = "Assets:TD_Knight_";  // temporary
      Position = "0 -4";
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
      name = "Red Gem";
      class = "Item";
      Position = "2 -2";
      SceneLayer = %layer;
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      name = "Blue Gem";
      class = "Item";
      Position = "2 -1";
      SceneLayer = %layer;
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      name = "Green Gem";
      class = "Item";
      Position = "2 -3";
      SceneLayer = %layer;
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

function testtown::setupTransitions(%this)
{
   %toGarden = new SceneObject(Transition)
   {
      height = 1;
      width = 4;
      
      Position = "2.5 9";
      toScene = "garden";
   };

   //  Add to Scene
   %this.add(%toGarden);
}