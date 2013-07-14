function CreateScene(%sceneName)
{
   //  Destroy the scene if it already exists
   if (isObject(%sceneName))
      destroyScene();
      
   //  Create Scene
   new Scene(%sceneName);
   
   // Sanity!
   if ( !isObject(GameWindow) )
   {
      error( "Created scene but no window available." );
      return;
   }
   
   SetSceneToWindow(%sceneName);
}

function DestroyScene(%scene)
{
    //  Finish if no scene available
    if ( !isObject(%scene) )
        return;

    //  Delete Scene
    %scene.delete();
}

// Save scene to file, persistent scene
function SaveScene(%scene)
{
   // File Path: Data/ProfileName.Lesson#.SceneName.taml
   %path = $DataSavePath @ Player.name @ "." @ Main.ActiveActivity @ "." @ %scene.getName() @ $DataSaveExtension;
   TamlWrite(%scene, %path, $DataSaveFormat);
}

function SetSceneToWindow(%scene)
{
   // Sanity!
   if ( !isObject(%scene) )
   {
      error( "Cannot set Scene to Window as the Scene is invalid." );
      return;
   }
   
   // Set scene to window.
   GameWindow.setScene(%scene);
}

function SetScene(%scene)
{
    // Sanity!
    if (!isObject(%scene))
    {
        error("Cannot set to use an invalid Scene.");
        return;
    }
   
    // Destroy the existing scene.  
    DestroyScene();

    // Needs the scene to be named this.
    //%scene.setName( "GameScene" );
    
    // Set the scene to the window.
    SetSceneToWindow(%scene);
}