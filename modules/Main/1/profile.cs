function CreateProfile()
{
   //echo("Create profile scriptobject");
   new ScriptObject(Profile)
   {
      password = "guest";
      year = 8;
      gender = "male";
      ethnicity = "maori";
	  
	  torsoColour = "blue";
   };
   
   // Create Default Player Character
   //echo("Create player composite sprite");
   %player = new CompositeSprite(Player)
   {
      displayName = "Test";
      class = "Character";
      gender = Profile.gender;
      ethnicity = Profile.ethnicity;
	  
	  torsoColour = Profile.torsoColour;
   };
   
   // Must be different than other characters to stop the player from pushing other characters
   %player.setDefaultDensity(0);
   
   Profile.character = %player;
}