// ===   Scene Functions   ===
function CreateScene()
{
   //  Destroy the scene if it already exists
   if (isObject(GameScene))
      destroyScene();
      
   //  Create Scene
   new Scene(GameScene);
   
   // Sanity!
   if ( !isObject(GameWindow) )
   {
      error( "Created scene but no window available." );
      return;
   }
   
   SetSceneToWindow();
}

function DestroyScene()
{
    //  Finish if no scene available
    if ( !isObject(GameScene) )
        return;

    //  Delete Scene
    GameScene.delete();
}

function SetSceneToWindow()
{
   // Sanity!
   if ( !isObject(GameScene) )
   {
      error( "Cannot set Scene to Window as the Scene is invalid." );
      return;
   }
   
   // Set scene to window.
   GameWindow.setScene( GameScene );
}

function SetScene( %scene )
{
    // Sanity!
    if ( !isObject(%scene) )
    {
        error( "Cannot set to use an invalid Scene." );
        return;
    }
   
    // Destroy the existing scene.  
    DestroyScene();

    // The Sandbox needs the scene to be named this.
    %scene.setName( "GameScene" );
    
    // Set the scene to the window.
    SetSceneToWindow();
}

// ===   Scene Window Functions   ===
function CreateSceneWindow()
{
    //  Check GameWindow exists
    if ( !isObject(GameWindow) )
    {
        //  Create Scene Window
        new SceneWindow(GameWindow);

        //  Set Gui Profile
        GameWindow.Profile = GuiDefaultProfile;  //  GuiDefaultProfile is used by default

        //  Place the sWindow on the Canvas
        Canvas.setContent(GameWindow);   //  GameWindow fills entire canvas
    }

    //GameWindow.setCameraPosition(0, 0);
    GameWindow.setCameraSize(20, 15);
    //GameWindow.setCameraZoom(5);
    //GameWindow.setCameraAngle(0);
    //CentreWindowOnSprite(%sprite);
}

function DestroySceneWindow()
{
    //  Finish if no window available
    if ( !isObject(GameWindow) )
        return;

    //  Delete window
    GameWindow.delete();
}

function CentreWindowOnSprite(%sprite)
{
   GameWindow.setCameraPosition(%sprite.position);
   
   // Schedule to centre camera on player sprite
   GameWindow.PositionSchedule = schedule(1, 0, CentreWindowOnSprite, %sprite);
}