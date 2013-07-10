// Treat this as like a class constructor for the lesson
function Lesson1::onAdd( %this )
{
   //	Add Tiled Map
   %mapSprite = new TmxMapSprite()
   {
      Map = "Year8:testtown_map";
   };
	
	GameScene.add( %mapSprite );
	
   createNPC("-4 -2");
   createPlayer("0 -2");
   
   //  Create Items
   %gemRed = new Sprite(RedGem)
   {
      name = "Red Gem";
      class = "Item";
      Position = "2 -2";
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   %gemBlue = new Sprite(BlueGem)
   {
      name = "Blue Gem";
      class = "Item";
      Position = "2 -1";
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   %gemGreen = new Sprite(GreenGem)
   {
      name = "Green Gem";
      class = "Item";
      Position = "2 -3";
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   gameScene.add(%gemRed);
   gameScene.add(%gemBlue);
   gameScene.add(%gemGreen);
}