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
}