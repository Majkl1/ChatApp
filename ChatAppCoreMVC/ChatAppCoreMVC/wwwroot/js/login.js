"use strict";

document.addEventListener("DOMContentLoaded", (event) => {
    var cookies = document.cookie.split('; ');
    var invalid = false;
    for (var i = 0; i < cookies.length; i++) {
        if (cookies[i].split('=')[0] == 'invalid-login' &&
            cookies[i].split('=')[1] == 'true') {
            document.getElementById('warning').innerText = 'Wrong username or password!';
            document.cookie = 'invalid-login=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
            invalid = true;
            break;
        }
    }
    if (!invalid) document.getElementById('warning').innerText = '';
});