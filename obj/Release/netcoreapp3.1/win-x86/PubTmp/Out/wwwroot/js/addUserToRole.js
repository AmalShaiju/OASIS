// Amal Shaiju 2021-03-29

function addUserToRole() {

    console.log("add user to role begin");

    // roleName to add
    var roleToAssign = $("#userRole-select").val()
    console.log(roleToAssign);


    //username to add
    var employeeUserName = $("#employee-select").val();

    console.log(roleToAssign + "" + employeeUserName);


    // Controller should contain [From Body]
    // Data should be stringified

    if (employeeUserName != null && roleToAssign != null) {
        if (employeeUserName != "" && roleToAssign != "") {
            $.ajax({
                type: "GET",
                url: "/UserRoles/AddUserToRole",
                data: {
                    'userName': employeeUserName,
                    'roleName': roleToAssign
                },
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response != null) {
                        console.log(response);

                        if (response.success) {
                            htmlToadd = ` <li id="${employeeUserName}-${roleToAssign}" class="col-12 row pl-5 mt-4 pr-0">
                            <div class="list-group-item  col-8 mr-4" ><p>${response.employeeName}<p></div >
                            <a class="btn btn-outline-primary col-1 p-0 mr-4" href="${getBaseUrl()}UserRoles/UserClaimEdit?userName=${employeeUserName}" id="Edit-${employeeUserName}">
                                <span class="material-icons">
                                           manage_accounts
                                </span>
                             </a>
                             <button class="btn btn-outline-danger col-1 p-0 m-0" onclick="removeUserFromRole(this)" id="delete-${employeeUserName}-${roleToAssign}">
                                 <span class="material-icons">
                                         delete
                                </span>
                             </button>
                                        </li >`
                            console.log($(`#${roleToAssign}-list`).html());
                            $(`#${roleToAssign}-list`).append(htmlToadd);

                            showStatusMsg(response.success, response.msg, 2000);
                        }
                        else {
                            showStatusMsg(response.success, response.msg, 2000);
                        }

                    } else {
                        showStatusMsg(false, "Something went wrong", 3000);
                    }
                },
                failure: function (response) {
                    showStatusMsg(false, "Something went wrong", 3000);
                },
                error: function (response) {
                    showStatusMsg(false, "Something went wrong", 3000);
                }
            });
        }
        else {
            if (roleToAssign == "") {
                showStatusMsg(false, "Please select a role from the dropdown list", 3000)
            }
            if (employeeUserName == "") {
                showStatusMsg(false, "Please select an employee from the dropdown list", 3000)

            }
        }
    }
};


function removeUserFromRole(e) {

    console.log("deleet user to role begin");

    // roleName to add
    var roleToRemove = e.id.split("-")[2];

    //username to add
    var employeeToRemove = e.id.split("-")[1];

    console.log(roleToRemove + "" + employeeToRemove);


    if (employeeToRemove != null && roleToRemove != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/RemoveUserFromRole",
            data: {
                'userName': employeeToRemove,
                'roleName': roleToRemove
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    console.log(response);

                    if (response.success) {
                        $(`#${employeeToRemove}-${roleToRemove}`).remove();
                        showStatusMsg(response.success, response.msg, 2000);
                    }
                    else {
                        showStatusMsg(response.success, response.msg, 2000);
                    }


                } else {
                    showStatusMsg(false, "Something went wrong", 3000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong", 3000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong", 3000);
            }
        });
    }
};