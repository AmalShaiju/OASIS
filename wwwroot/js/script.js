// Amal Shaiju 2021-01-23

function divVisibility(i) {
    console.log(document.getElementById(i+"-ddl"));

    if (document.getElementById(i+"-ddl").style.display != "block")
           document.getElementById(i+"-ddl").style.display = "block";
        else
            document.getElementById(i+"-ddl").style.display = "None";

}