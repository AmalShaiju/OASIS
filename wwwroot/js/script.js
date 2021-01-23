// Amal Shaiju 2021-01-23

var options = document.getElementsByClassName(".index-drop-down-menu");

console.log(options.length)
var visibleDivId;

function divVisibility(i) {

    var menu = document.getElementsByClassName("index-drop-down-menu");

    for (var j = 0; j < menu.length; j++) {

        console.log(menu[j].id, i)
        if (menu[j].id != i + "-ddl") {

            menu[j].style.display = "None";

        }
    }

    if (document.getElementById(i + "-ddl").style.display != "block") {
        document.getElementById(i + "-ddl").style.display = "block";
    }

    else {
        document.getElementById(i + "-ddl").style.display = "None";
    }

}
