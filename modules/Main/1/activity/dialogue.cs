$DialogueResponseMax = 9;

function Dialogue::setup(%this, %text)
{
	%this.dialogue = %text;
	
	%this.responseText[0] = "[End Dialogue]";
	%this.responseCount = 0;
	
	%this.canEnd = true;
	%this.canRepeat = true;
	%this.faceTarget = true;
}

//	Display dialogue elements
function Dialogue::display(%this, %owner, %target)
{
	DialogueLabel.setText(%owner.displayName);
	DialogueText.setText(%this.dialogue);
	
	%this.updateResponseArray();
}

//	Updates GUI to display responses from this dialogue
function Dialogue::updateResponseArray(%this)
{
	%ResponseArray.clear();
	
	for (%i = 1; %i <= %this.responseCount; %i++)
	{
	}
}

//	Add a response for the player to select
//	Text = the text displayed for this response
//	Next Dialogue = the dialogue object this response will lead to when selected
function Dialogue::addResponse(%this, %text, %nextDialogue)
{
	if (%this.responseCount >= $DialogueResponseMax)
	{
		%this.responseCount++;
		%i = %this.responseCount;
		
		%this.responseText[%i] = %text;
		%this.responseDialogue[%i] = %nextDialogue;
	}
	else
		warn("Cannot add response to" SPC %this.dialogue @ ". Max response number reached.");
}

//	Remove response by index
//	- or -
//	Remove all responses leading to a dialogue
/*	NOTE: Since there's no way to tell the difference
	between parameter "int" and "Dialogue", as
	parameter types aren't enforced, this means I'll
	have to combine them and do type checking.	*/
function Dialogue::removeResponse(%this, %input)
{
	//	For Dialogue
	if (%input.class == Dialogue)
	{
		for (%i = 1; %i <= %this.responseCount; %i++)
			if (%responseDialogue[%i] == %input)
				//	Recurse using index
				%this.removeDialogue(%i);
	}
	//	For index
	else if (%input > 0 && %input < $DialogueResponseMax)
	{
		//	Shift all responses after target response back one slot, overwriting the target
		for (%i = %input + 1; %i <= %this.responseCount; %i++)
		{
			%this.responseText[%i - 1] = %this.responseText[%i];
			%this.responseDialogue[%i - 1] = %this.responseDialogue[%i];
		}
		
		%this.responseCount--;
	}
	else
		error("Wrong input type given to removeResponse for" SPC %this.dialogue);
}

//	
function ResponseArray::addResponse(%this, %i)
{
	//	Response 1 at the top, response 0 at the bottom
	if (%i == 0)
		%i = %this.responseCount + 1;
	
	%extent = %this.extent;
	
    %button = new GuiButtonCtrl()
    {
        canSaveDynamicFields = "0";
        HorizSizing = "width";
        VertSizing = "top";
        isContainer = "0";
        Profile = "DialogueResponseProfile";
        Position = "0" SPC ($GUIResponseHeight * (%i - 1));
        Extent = %extent.x SPC "30";
		MinExtent = "80 30";
        Visible = "1";
        isContainer = "0";
        Active = "1";
        text = %i @ "." TAB %responseText[%i];
        groupNum = "-1";
        buttonType = "PushButton";
        useMouseEvents = "1";
    };
     
    %button.command = "";
    
    %this.add(%button);
}