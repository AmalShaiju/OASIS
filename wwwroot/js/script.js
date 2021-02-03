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

//Amal shaiju 2021-01-23

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
        document.getElementById("page-msg").innerHTML = pagemsg + " " + "Create";
    }
    else if (url.includes("details")) {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg + " " + "Details";
    }
    else if (url.includes("edit")) {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg + " " + "Edit";
    }
    else {
        var pagemsg = document.getElementById("page-msg").innerHTML;
        document.getElementById("page-msg").innerHTML = pagemsg + " " + "Delete";
    }
}

//Amal shaiju 2021-02-02

// Accesiblity tab slider
var accesiblityBtn = document.querySelector(".accesiblity-tab");
document.querySelector(".accesiblity-controller").addEventListener("click", () => {
    if (accesiblityBtn.style.transform == "translateX(0%)") {
        accesiblityBtn.style.transform = "translateX(79%)";
    }
    else {
        accesiblityBtn.style.transform = "translateX(0%)";
    }
})


// Accesiblity Items *

//Accesiblity funtion call controller
var accesiblityFuncControl = false;

// All type elements
var pEL = document.querySelectorAll("p");
var aEl = document.querySelectorAll("a");
var hoEl = document.querySelectorAll("h1");
var htEl = document.querySelectorAll("h2");
var hthEl = document.querySelectorAll("h3");
var thEl = document.querySelectorAll("th");
var tdEl = document.querySelectorAll("td");
var strongEl = document.querySelectorAll("strong");
var labelEl = document.querySelectorAll("label");


// Accesiblity Items functions
var functions = {


    // Increase Text size
    1: function () {
        if (accesiblityBtn) {
            for (var i = 0; i < pEL.length; i++) {
                var style = window.getComputedStyle(pEL[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                pEL[i].style.fontSize = (fontSize + 2) + "px";
            }

            for (var i = 0; i < aEl.length; i++) {
                var style = window.getComputedStyle(aEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                aEl[i].style.fontSize = (fontSize + 2) + "px";
            }
            for (var i = 0; i < hoEl.length; i++) {
                var style = window.getComputedStyle(hoEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                hoEl[i].style.fontSize = (fontSize + 2) + "px";
            }
            for (var i = 0; i < htEl.length; i++) {
                var style = window.getComputedStyle(htEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                htEl[i].style.fontSize = (fontSize + 2) + "px";
            }

            for (var i = 0; i < thEl.length; i++) {
                var style = window.getComputedStyle(thEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                thEl[i].style.fontSize = (fontSize + 2) + "px";
            }

            for (var i = 0; i < tdEl.length; i++) {
                var style = window.getComputedStyle(tdEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                tdEl[i].style.fontSize = (fontSize + 2) + "px";
            }
            for (var i = 0; i < strongEl.length; i++) {
                var style = window.getComputedStyle(strongEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                strongEl[i].style.fontSize = (fontSize + 2) + "px";
            }
            for (var i = 0; i < labelEl.length; i++) {
                var style = window.getComputedStyle(labelEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                labelEl[i].style.fontSize = (fontSize + 2) + "px";
            }
            for (var i = 0; i < hthEl.length; i++) {
                var style = window.getComputedStyle(hthEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                hthEl[i].style.fontSize = (fontSize + 2) + "px";
            }
        }

        //document.querySelectorAll("p").style.fontSize = "2" ;
    },


    // decrease Text size
    2: function () {
        if (accesiblityBtn) {
            for (var i = 0; i < pEL.length; i++) {
                var style = window.getComputedStyle(pEL[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                pEL[i].style.fontSize = (fontSize - 2) + "px";
            }

            for (var i = 0; i < aEl.length; i++) {
                var style = window.getComputedStyle(aEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                aEl[i].style.fontSize = (fontSize - 2) + "px";
            }
            for (var i = 0; i < hoEl.length; i++) {
                var style = window.getComputedStyle(hoEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                hoEl[i].style.fontSize = (fontSize - 2) + "px";
            }
            for (var i = 0; i < htEl.length; i++) {
                var style = window.getComputedStyle(htEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                htEl[i].style.fontSize = (fontSize - 2) + "px";
            }

            for (var i = 0; i < thEl.length; i++) {
                var style = window.getComputedStyle(thEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                thEl[i].style.fontSize = (fontSize - 2) + "px";
            }

            for (var i = 0; i < tdEl.length; i++) {
                var style = window.getComputedStyle(tdEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                tdEl[i].style.fontSize = (fontSize - 2) + "px";
            }
            for (var i = 0; i < strongEl.length; i++) {
                var style = window.getComputedStyle(strongEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                strongEl[i].style.fontSize = (fontSize - 2) + "px";
            }
            for (var i = 0; i < labelEl.length; i++) {
                var style = window.getComputedStyle(labelEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                labelEl[i].style.fontSize = (fontSize - 2) + "px";
            }
            for (var i = 0; i < hthEl.length; i++) {
                var style = window.getComputedStyle(hthEl[i], null).getPropertyValue('font-size');
                var fontSize = parseFloat(style);
                hthEl[i].style.fontSize = (fontSize - 2) + "px";
            }
        }
    },
    3: function () {
        if (accesiblityFuncControl) {
            console.log(document.querySelector("HTML").getAttribute("style"));

            if (document.querySelector("HTML").getAttribute("style") != " -moz-filter: grayscale(100%); - webkit-filter: grayscale(100%); filter: gray; /* IE6-9 */ filter: grayscale(100%)" ) {
                document.querySelector("HTML").setAttribute("style", " -moz-filter: grayscale(100%); - webkit-filter: grayscale(100%); filter: gray; /* IE6-9 */ filter: grayscale(100%)");
            }
            else {
                document.querySelector("HTML").setAttribute("style", null);
            }
            
         }
    },
    4: function () { console.log("4"); },
    5: function () { console.log("5"); },
    6: function () { console.log("6"); },
    7: function () { window.location.reload(); }
};

// Loop Through the accesiblity links and add the event listner
var accesiblitytabs = document.querySelectorAll(".accesiblity-body > ul > li")
var counter = 1;
accesiblitytabs.forEach((link) => {
    link.addEventListener("click", functions[`${counter}`])
    counter++;
})

accesiblityFuncControl = true;




