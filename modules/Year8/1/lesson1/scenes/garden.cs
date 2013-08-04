function garden::onAdd(%this)
{
}

function garden::setup(%this)
{
   %this.setName("garden");

   //	Add Tiled Map
   %mapSprite = new TmxMapSprite()
   {
      Map = "Year8:garden_map";
   };
	
	%this.add(%mapSprite);
	
	%layer = 13;
   
   %this.setupCharacters(%layer);
   %this.setupItems(%layer);
   %this.setupTransitions();
}

function garden::setupCharacters(%this, %layer)
{
   //  Create Player
   createPlayer(%this, "0 0", %layer);
   
   //  Barbarian
   %barbarian = new CompositeSprite(Barbarian)
   {
      //name = "Barbarian";
      class = "Character";
      imageName = "Assets:TD_Barbarian_";  // temporary
      Position = "-3 0";
      SceneLayer = %layer;
   };
   
   //  Dwarf
   %dwarf = new CompositeSprite(Dwarf)
   {
      //name = "Dwarf";
      class = "Character";
      imageName = "Assets:TD_Dwarf";  // temporary
      Position = "-3 2";
      SceneLayer = %layer;
   };
   
   //  Knight
   %knight = new CompositeSprite(Knight)
   {
      //name = "Knight";
      class = "Character";
      imageName = "Assets:TD_Knight_";  // temporary
      Position = "3 2";
      SceneLayer = %layer;
   };

   // Add to Scene
   //GameScene.add(Player);
   %this.add(%barbarian);
   %this.add(%dwarf);
   %this.add(%knight);
}

function garden::setupItems(%this, %layer)
{
   //  Red Gem
   %gemRed = new Sprite(RedGem)
   {
      name = "Red Gem";
      class = "Item";
      Position = "5 -5";
      SceneLayer = %layer;
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      name = "Blue Gem";
      class = "Item";
      Position = "5 5";
      SceneLayer = %layer;
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      name = "Green Gem";
      class = "Item";
      Position = "-5 5";
      SceneLayer = %layer;
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

function garden::setupTransitions(%this)
{
   %toTestTown = new Trigger()
   {
      class = "Transition";
      height = 1;
      width = 3;
      
      Position = "0 -9";
      toScene = "testtown";
   };

   //  Add to Scene
   %this.add(%toTestTown);
}