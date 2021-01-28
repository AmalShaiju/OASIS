// Amal Shaiju 2021-01-23
function divVisibility(i) {

    var menu = document.getElementsByClassName("index-drop-down-menu");

    // Closes the div that are shown except the ones that's clicked
    for (var j = 0; j < menu.length; j++) {

        console.log(menu[j].id, i)
        if (menu[j].id != i + "-ddl") {

            menu[j].style.display = "None";

        }
    }

    // If the clicked div is hidden show it
    if (document.getElementById(i + "-ddl").style.display != "block") {
        document.getElementById(i + "-ddl").style.display = "block";
    }

    else {
        document.getElementById(i + "-ddl").style.display = "None";
    }
}

﻿//Amal shaiju 2021-01-23

// Change image based on URL
var url = window.location.href.toString().toLowerCase();
console.log(url)


//Determines the page and adds it to the status msg
if (url.includes("employees")) {
    var homeSideBar = document.getElementById("employee-side-bar").style.backgroundColor = "#7460ee";;
    var home = document.getElementById("employee").style.backgroundColor = "rgb(116, 96, 238, 0.2)";
    var employeeLogo = document.getElementById("employeeLogo").src = "/resources/employee-alt.png";
    var text = document.getElementById("v-pills-employee-tab").style.color = "#7460ee";
    var pagemsg = document.getElementById("page-msg").innerHTML = "Employees";
}
else if (url.includes("customers")) {
    var homeSideBar = document.getElementById("customer-side-bar").style.backgroundColor = "#7460ee";;
    var home = document.getElementById("customer").style.backgroundColor = "rgb(116, 96, 238, 0.2)";
    var CustomerLogo = document.getElementById("customerLogo").src = "/resources/user-alt.png";
    var text = document.getElementById("v-pills-customer-tab").style.color = "#7460ee";
    var pagemsg = document.getElementById("page-msg").innerHTML = "Customers";

}
else if (url.includes("projects")) {
    var homeSideBar = document.getElementById("project-side-bar").style.backgroundColor = "#7460ee";;
    var home = document.getElementById("project").style.backgroundColor = "rgb(116, 96, 238, 0.2)";
    var projectLogo = document.getElementById("projectLogo").src = "/resources/project-alt.png"
    var text = document.getElementById("v-pills-projct-tab").style.color = "#7460ee";
    var pagemsg = document.getElementById("page-msg").innerHTML = "Projects";

}
else if (url.includes("roles")) {
    var homeSideBar = document.getElementById("role-side-bar").style.backgroundColor = "#7460ee";
    var home = document.getElementById("role").style.backgroundColor = "rgb(116, 96, 238, 0.2)";
    var roleLogo = document.getElementById("roleLogo").src = "/resources/roles-alt.png"
    var text = document.getElementById("v-pills-role-tab").style.color = "#7460ee";
    var pagemsg = document.getElementById("page-msg").innerHTML = "Roles";

}
else {
    var homeSideBar = document.getElementById("home-side-bar").style.backgroundColor = "#7460ee";;
    var homeLogo = document.getElementById("homeLogo").src = "/resources/dash-alt1.png";
    var home = document.getElementById("home").style.backgroundColor = "rgb(116, 96, 238, 0.2)";
    var text = document.getElementById("v-pills-home-tab").style.color = "#7460ee";
    var pagemsg = document.getElementById("page-msg").innerHTML = "Dashboard";

}

//Adds Method Name to Status Msg
if (url.includes("create") || url.includes("edit") || url.includes("details") || url.includes("delete")) {
    if (url.includes("create")) {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg +" " + "Create";
    }
    else if (url.includes("details")) {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg +" " + "Details";
    }
    else if (url.includes("edit")) {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg + " " +"Edit";
    }
    else{
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg + " " +"Delete";
    }
}