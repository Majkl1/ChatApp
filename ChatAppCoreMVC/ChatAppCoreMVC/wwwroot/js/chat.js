"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendBtn").disabled = true;

connection.start().then(() => {
    document.getElementById("sendBtn").disabled = false;

    connection.invoke('GetConnectionId')
        .then(function (connectionId) {
            var activeUser = document.getElementById("userFrom").textContent;

            connection.invoke('SetConnectionId', activeUser, connectionId)
                .catch(err => console.error(err.toString()));
        }).catch(err => console.error(err.toString()));

}).catch((err) => {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", (userFrom, userTo, message) => {
    if (userFrom == document.getElementById("userTo").textContent || userTo == document.getElementById("userTo").textContent) {
        var msgText = userFrom + ": " + message;
        var li = document.createElement("li");
        li.textContent = msgText;
        document.getElementById("msgBox").appendChild(li);
    }
    
});

function send() {
    var userTo = document.getElementById("userTo").textContent;
    var userFrom = document.getElementById("userFrom").textContent;
    var message = document.getElementById("msgText").value;
    document.getElementById("msgText").value = "";

    connection.invoke('GetConnectionId')
        .then((connectionIdFrom) => {
            connection.invoke('GetConnectionIdOfUser', userTo)
                .then((connectionIdTo) => {
                    connection.invoke("SendMessage", userFrom, userTo, message, connectionIdFrom, connectionIdTo).catch(err => console.error(err.toString()));
                }).catch(err => console.error(err.toString()));
        }).catch(err => console.error(err.toString()));
}

