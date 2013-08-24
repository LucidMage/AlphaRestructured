function DialogueTree::setup(%this, %owner)
{
	%this.owner.dialogueTree = %this;
	
	//%this.selectedDialogue
}

//	Initialize dialogue with the owner
//	Target = who the owner is talking to
function DialogueTree::openDialogue(%this, %target)
{
	echo("Opening Dialogue");
	
	if (%this.onOpen())
	{
		DialogueContainer.setVisible(true);
		ResponseContainer.setVisible(true);
		
		//	Responses
		//ResponseArray
		
		//Player.setDialogueBehaviours();
	}
}

function DialogueTree::closeDialogue(%this)
{
	echo("Closing Dialogue");
	
	DialogueContainer.setVisible(false);
	ResponseContainer.setVisible(false);
	
	if (%this.onClose())
	{
		Player.setGeneralBehaviours();
	}
}

//	Callbacks
function DialogueTree::onOpen(%this)	{	return true;	}
function DialogueTree::onClose(%this)	{	return true;	}
function DialogueTree::onNext(%this)	{	return true;	}