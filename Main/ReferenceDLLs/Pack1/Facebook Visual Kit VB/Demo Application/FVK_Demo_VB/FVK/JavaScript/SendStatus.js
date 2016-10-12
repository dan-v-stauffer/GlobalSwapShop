var commonName = "";

function CreateCommonName2(sender) {
    var buttonId = sender.id;
    var index = buttonId.indexOf("StatusSentButtonControl");
    commonName = buttonId.substring(0, index);
}

function OnStatusClick(sender) {
    sender.style.color = "black";
    sender.value = "is ";
    var range = sender.createTextRange();
    range.move('character', 3);
    range.select();
}

function OnSendStatus(sender) {
    CreateCommonName2(sender);
    var message = document.getElementById(commonName + "SendStatusText").value;
    var statusSentButton = document.getElementById(commonName + "StatusSentButton");
    var sendErrorButton = document.getElementById(commonName + "SendErrorButton");

    FB.api('/me/feed', 'post', { 'message': message }, function(response) {
        if (!response || response.error) {
            sendErrorButton.click();
        }
        else {
            statusSentButton.click();
        }
    });
}