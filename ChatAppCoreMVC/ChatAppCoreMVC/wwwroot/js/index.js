"use strict";

//var model = @Html.Raw(Json.Encode(Model));
//var value = '@Model.AllUsers';
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var users = document.getElementsByClassName("usersBtn");

for (var i = 0; i < users.length; i++) {
    users[i].addEventListener("click", function () { openChat(this); });
    console.log("bruuuh");
}

connection.start();

function openChat(userBtn) {
    console.log(userBtn);

    connection.invoke('addUserToQueue', document.getElementById("userFrom").textContent)
        .then(function () {
            if (window.location.toString().split('/').length == 5) {
                window.location.replace("chat/user/" + userBtn.value);
            }
            else {
                window.location.replace(userBtn.value);
            }
            
        }).catch(err => console.error(err.toString()));;
}