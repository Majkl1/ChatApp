"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendBtn").disabled = true;

connection.start().then(function() {
    document.getElementById("sendBtn").disabled = false;

    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            var activeUser = document.getElementById("userFrom").textContent;
            sessionStorage.setItem(activeUser, connectionId);
        }).catch(err => console.error(err.toString()));;

}).catch(function(err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (userFrom, userTo, message) {
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
    var connectionIdFrom = sessionStorage.getItem(userFrom);
    var connectionIdTo = sessionStorage.getItem(userTo);
    connection.invoke("SendMessage", userFrom, userTo, message, connectionIdFrom, connectionIdTo).catch(function(err) {
        return console.error(err.toString())
    });
}