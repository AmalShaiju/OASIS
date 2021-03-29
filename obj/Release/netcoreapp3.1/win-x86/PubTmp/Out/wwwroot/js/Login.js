// Amal Shaiju 2021-03-26


$("#btn-login").click(function () {
    console.log('clicked');

    var UserToLogin = new Object();
    UserToLogin.Username = ($('#txtUserName').val()).toString();
    UserToLogin.Password = ($('#txtPassword').val()).toString();
    UserToLogin.RememberMe = false;
    UserToLogin.ReturnUrl = "http://localhost:63341/Employees"

    console.log(UserToLogin)

    // Controller should contain [From Body]
    // Data should be stringified

    if (UserToLogin != null) {
        $.ajax({
            type: "POST",
            url: "/UserRoles/LoginUser",
            data: JSON.stringify(UserToLogin),
            contentType: "application/json;",
            success: function (response) {
                if (response != null) {

                    console.log(JSON.parse(response));

                    // if user logged in 
                    if (JSON.parse(response)) {
                        window.location.replace(getBaseUrl() + "Employees");
                    }
                    else {
                        $("#login-error").css({ "display": "block"})
                    }


                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert("failed");
            },
            error: function (response) {
                alert(response);
                console.log(response);

            }
        });
    }
});  

