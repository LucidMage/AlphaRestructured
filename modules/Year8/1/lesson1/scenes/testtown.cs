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
   %this.setupTransitions();
   
   //	Create GUI stuff here for now
   $label = createCustomLabel("Now it has changed");
   
	GlobalActionMap.bind( keyboard, "space",  createDialogueBox);   // Press '`' to open console
}

function createDialogueBox()
{
   
    // Is the console awake?
    if ( DialogueBox.isAwake() )
    {
        Canvas.popDialog(DialogueBox);    
        Canvas.popDialog($label);   
        return;
    }
    
    Canvas.pushDialog(DialogueBox);
    Canvas.pushDialog($label);
}

function testtown::setupCharacters(%this, %layer)
{
   //  Create Player
   createPlayer(%this, "0 -2", %layer);
   
   //  Barbarian
   %barbarian = new CompositeSprite(Barbarian)
   {
      displayName = "Barbarian";
      class = "Character";
      imageName = "Assets:TD_Barbarian_";  // temporary
      Position = "-2 -2";
      SceneLayer = %layer;
   };
   //Character.setup(%barbarian);
   
   //  Dwarf
   %dwarf = new CompositeSprite(Dwarf)
   {
      displayName = "Dwarf";
      class = "Character";
      imageName = "Assets:TD_Dwarf";  // temporary
      Position = "-4 -2";
      SceneLayer = %layer;
   };
   
   //  Knight
   %knight = new CompositeSprite(Knight)
   {
      displayName = "Knight";
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
      displayName = "Red Gem";
      class = "Item";
      Position = "2 -2";
      SceneLayer = %layer;
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      displayName = "Blue Gem";
      class = "Item";
      Position = "2 -1";
      SceneLayer = %layer;
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      displayName = "Green Gem";
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
   new SceneObject(ToGarden)
   {
      class = "Transition";
      height = 1;
      width = 4;
      
      Position = "2.5 9";
      toScene = "garden";
   };

   //  Add to Scene
   %this.add(ToGarden);
}