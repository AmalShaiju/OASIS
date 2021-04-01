// Amal Shaiju 2021-03-26


$("#btn-login").click(function () {
    console.log('clicked');

    var UserToLogin = new Object();
    UserToLogin.Username = ($('#txtUserName').val()).toString().trim();
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

                    if (response.success) {

                        showStatusMsg(response.success, response.msg, 2000)
                        setTimeout(2000)
                        window.location.replace(getBaseUrl());

                    }
                    else {
                        showStatusMsg(response.success, response.msg, 4000)
                    }


                } else {
                    showStatusMsg(false, "Something went wrong", 4000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong", 4000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong", 4000);
            }
        });
    }
});  


function ShowForgotPasswordForm() {
    $('#login-form').slideUp(300).fadeOut(100);

    $('#forgot-password-form').slideDown(500).delay(300).fadeIn(500);

}

function loginFormShow() {
    $('#login-form').slideDown(500).delay(300).fadeIn(500);

    $('#forgot-password-form').slideUp(300).fadeOut(100);
}

$('#send-password').click(function () {
    console.log("password reset started")

    var email = $("#ForgotEmail").val().trim();

    if (email != null) {
        $.ajax({
            type: "POST",
            url: "/UserRoles/ForgotPassword",
            data: JSON.stringify(email),
            contentType: "application/json;",
            success: function (response) {
                if (response != null) {

                    if (response.success) {
                        showStatusMsg(response.success, response.msg, 4000)
                        setTimeout(1000)
                        window.location.replace(getBaseUrl());
                    }
                    else {
                        showStatusMsg(response.success, response.msg,4000)

                    }

                } else {
                    showStatusMsg(false, "Something went wrong",4000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong",4000);
            },
            error: function (response) {
                    showStatusMsg(false, "Something went wrong",4000);
            }
        });
    }
});

