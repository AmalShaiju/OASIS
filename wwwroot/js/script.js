//Amal shaiju 2021-01-23

// Change image based on URL
var url = window.location.href.toString().toLowerCase();
console.log(url)



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

//if (url.includes("employees/create")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Employee Create";
//}
//else if (url.includes("employees/details")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Employee Details";
//}
//else if (url.includes("employees/edit")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Employee Details";
//}
//else if (url.includes("customers/create")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Customer Create";
//}
//else if (url.includes("customers/edit")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Customer Edit";
//}
//else if (url.includes("customers/details")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Customer Create";
//}
//else if (url.includes("customers/edit")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Customer Edit";
//}
//else if (url.includes("roles/details")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Roles Details";
//}
//else if (url.includes("roles/edit")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Roles Edit";
//}
//else if (url.includes("roles/create")) {
//    var pagemsg = document.getElementById("page-msg").innerHTML = "Roles Create";
//}