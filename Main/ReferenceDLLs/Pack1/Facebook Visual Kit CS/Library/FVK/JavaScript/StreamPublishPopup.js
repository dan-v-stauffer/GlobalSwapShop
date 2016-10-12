var commonName = "";
var userMessageObject;

function CreateCommonName(sender) {
    var buttonId = sender.id;
    var index = buttonId.indexOf("PublishButton");
    commonName = buttonId.substring(0, index);
}

function StreamPublish(sender) {
    CreateCommonName(sender);
    StreamPublishNow();
}

function StreamPublishNow() {
    if (graphApiInitialized != true) {
        setTimeout('StreamPublishNow()', 100);
        return;
    }

    var name1 = document.getElementById(commonName + "NameHiddenField").value;
    var href1 = document.getElementById(commonName + "HrefHiddenField").value;
    var caption1 = document.getElementById(commonName + "CaptionHiddenField").value;
    var description1 = document.getElementById(commonName + "DescriptionHiddenField").value;
    var messagePrompt1 = document.getElementById(commonName + "MessagePromptHiddenField").value;
    var userMessage1 = document.getElementById(commonName + "UserMessageHiddenField").value;
    var actionLinks1 = document.getElementById(commonName + "ActionLinksHiddenField").value;
    var targetId1 = document.getElementById(commonName + "TargetIdHiddenField").value;
    var actorId1 = document.getElementById(commonName + "ActorIdHiddenField").value;
    var media1 = document.getElementById(commonName + "MediaHiddenField").value;
    var properties1 = document.getElementById(commonName + "PropertiesHiddenField").value;

    properties1 = jsonParse(properties1);
    media1 = jsonParse(media1);
    actionLinks1 = jsonParse(actionLinks1);

    var attachment1 = { name: name1, href: href1, caption: caption1, description: description1, properties: properties1, media: media1 };

    FB.ui(
    {
        method: 'stream.publish',
        message: userMessage1,
        attachment: attachment1,
        action_links: actionLinks1,
        user_message_prompt: messagePrompt1,
        target_id: targetId1,
        actor_id: actorId1
    },
       ClickPublishPopup
   );
}

function ClickPublishPopup(response) {
    var postIdHidden = document.getElementById(commonName + "ReturnedPostIdHiddenField");

    if (response != null) {
        postIdHidden.value = response.post_id;
    }
    else {
        postIdHidden.value = "null";
    }
        
    var sendButton = document.getElementById(commonName + "ConfirmedSendButton");
    sendButton.click();
}


function SelectTarget(objectName, sender) {
    var target = document.getElementById(objectName);
    target.value = sender.value;
}