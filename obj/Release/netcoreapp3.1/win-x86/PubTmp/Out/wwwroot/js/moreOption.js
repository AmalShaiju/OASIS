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


