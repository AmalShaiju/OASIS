// Amal Shaiju 2021-03-30
function UpdateClaim(e) {
    var type = e.id.split("-")[0];
    if ($(`#${e.id} `).prop('checked'))
    {
        var value = "True"
        console.log("true")
    }
    else {
        var value = "False"
        console.log("false")

    }
    var role = e.id.split("-")[2];



    console.log(`#${e.id} `);

    if (type != null && value != null && role != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/UpdateClaims",
            data: {
                'claimType': type,
                'claimValue': value,
                'roleName': role
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {

                    if (response.success) {
                        showStatusMsg(response.success, response.msg, 1000);
                    }
                    else {
                        showStatusMsg(response.success, response.msg, 1000);
                    }


                } else {
                    showStatusMsg(false, "Something went wrong", 2000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong", 2000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong", 2000);

            }
        });
    }
}

function UpdateUserClaim(e) {
    var type = e.id.split("-")[0];

    if ($(`#${e.id} `).prop('checked')) {
        var value = "True"
        console.log("true")
    }
    else {
        var value = "False"
        console.log("false")

    }

    var user = e.id.split("-")[2];



    console.log(`#${e.id} `);

    if (type != null && value != null && user != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/UpdateUserClaims",
            data: {
                'claimType': type,
                'claimValue': value,
                'userName': user
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    if (response.success) {
                        showStatusMsg(response.success, response.msg,1000);
                    }
                    else {
                        showStatusMsg(response.success, response.msg,1000);
                    }
                } else {
                    showStatusMsg(false, "Something went wrong", 2000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong", 2000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong",2000);
            }
        });
    }
}
