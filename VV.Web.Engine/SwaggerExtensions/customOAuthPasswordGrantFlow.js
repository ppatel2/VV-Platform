//$('#explore').off();

//$('#explore').click(function () {
//    var key = $('#input_apiKey')[0].value;
//    var credentials = key.split(':'); //username:password expected

//    $.ajax({
//        url: "localhost:8090/token",
//        type: "post",
//        contenttype: 'x-www-form-urlencoded',
//        data: "grant_type=password&username=" + credentials[0] + "&password=" + credentials[1],
//        success: function (response) {
//            var bearerToken = 'Bearer ' + response.access_token;

//            window.swaggerUi.api.clientAuthorizations.add('Authorization', new SwaggerClient.ApiKeyAuthorization('Authorization', bearerToken, 'header'));
//            window.swaggerUi.api.clientAuthorizations.remove("api_key");
//            alert("Login successfull");
//        },
//        error: function (xhr, ajaxoptions, thrownerror) {
//            alert("Login failed!");
//        }
//    });
//});

//$('#input_apiKey').change(function () {
//    var key = $('#input_apiKey')[0].value;
//    var credentials = key.split(':'); //username:password expected
//    $.ajax({
//        url: "localhost:8090/token",
//        type: "post",
//        contenttype: 'x-www-form-urlencoded',
//        data: "grant_type=password&username=" + credentials[0] + "&password=" + credentials[1],
//        success: function (response) {
//            var bearerToken = 'Bearer ' + response.access_token;
//            window.authorizations.add('key', new ApiKeyAuthorization('Authorization', bearerToken, 'header'));
//        },
//        error: function (xhr, ajaxoptions, thrownerror) {
//            alert("Login failed!");
//        }
//    });
//});

//(function () {
//    $(function () {
//        var basicAuthUI =
//            '<div class="input"><input placeholder="username" id="input_username" name="username" type="text" size="10"></div>' +
//            '<div class="input"><input placeholder="password" id="input_password" name="password" type="password" size="10"></div>';
//        $(basicAuthUI).insertBefore('#api_selector div.input:last-child');
//        $("#input_apiKey").remove();
        
//        $('#input_username').change(addAuthorization);
//        $('#input_password').change(addAuthorization);
//    });
    
//    function addAuthorization() {
//        var username = $('#input_username').val();
//        var password = $('#input_password').val();
//        if (username && username.trim() != "" && password && password.trim() != "") {
//            var basicAuth = new SwaggerClient.PasswordAuthorization('basic', username, password);
//            window.swaggerUi.api.clientAuthorizations.add("basicAuth", basicAuth);
//            console.log("authorization added: username = " + username + ", password = " + password);
//        }
//    }
//})();


(function () {
    $(function () {
        var basicAuthUI =
            '<div class="input"><input placeholder="username" id="input_username" name="username" type="text" size="10"></div>' +
            '<div class="input"><input placeholder="password" id="input_password" name="password" type="password" size="10"></div>';
        $(basicAuthUI).insertBefore('#api_selector div.input:last-child');
        $("#input_apiKey").remove();
        $('#explore').html("Login");

        $('#explore').click(function () {
            var username = $('#input_username').val();
            var password = $('#input_password').val();

            if (username && username.trim() != "" && password && password.trim() != "") {
                $.ajax({
                    url: "/token",
                    type: "POST",
                    contenttype: 'x-www-form-urlencoded',
                    
                    data: "grant_type=password&username=" + username + "&password=" + password,
                    success: function (response) {
                        var bearerToken = 'Bearer ' + response.access_token;
                        window.swaggerUi.api.clientAuthorizations.add('Authorization', new SwaggerClient.ApiKeyAuthorization('Authorization', bearerToken, 'header'));

                        alert("Login successfull");
                    },
                    error: function (xhr, ajaxoptions, thrownerror) {
                        alert("Login failed!");
                    }
                });
            }
        });
    });
})();

//$('#explore').click(function () {
//    var key = $('#input_apiKey')[0].value;
//    var credentials = key.split(':'); //username:password expected

//    $.ajax({
//        url: "localhost:8090/token",
//        type: "post",
//        contenttype: 'x-www-form-urlencoded',
//        data: "grant_type=password&username=" + credentials[0] + "&password=" + credentials[1],
//        success: function (response) {
//            var bearerToken = 'Bearer ' + response.access_token;

//            window.swaggerUi.api.clientAuthorizations.add('Authorization', new SwaggerClient.ApiKeyAuthorization('Authorization', bearerToken, 'header'));
//            window.swaggerUi.api.clientAuthorizations.remove("api_key");
//            alert("Login successfull");
//        },
//        error: function (xhr, ajaxoptions, thrownerror) {
//            alert("Login failed!");
//        }
//    });
//});