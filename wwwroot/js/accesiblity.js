//Amal shaiju 2021-02-02

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

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

var textEl = [
    document.querySelectorAll("p"),
    document.querySelectorAll("a"),
    document.querySelectorAll("h1"),
    document.querySelectorAll("h2"),
    document.querySelectorAll("h3"),
    document.querySelectorAll("th"),
    document.querySelectorAll("td"),
    document.querySelectorAll("strong"),
    document.querySelectorAll("label")
]



var containerEl = [
    document.querySelector("#header"),
    document.querySelector(".body-top"),
    document.querySelector(".body"),
]



var highContrast = false;

// Accesiblity Items functions
var functions = {


    // Increase Text size
    1: function () {
        if (accesiblityBtn) {

            console.log("1")
            for (var i = 0; i < textEl.length; i++) { // 0
                for (var j = 0; j < textEl[i].length; j++) { // 0
                    var style = window.getComputedStyle(textEl[i][j], null).getPropertyValue('font-size');
                    var fontSize = parseFloat(style);
                    textEl[i][j].style.fontSize = (fontSize + 2) + "px";
                }
            }
        }

        //document.querySelectorAll("p").style.fontSize = "2" ;
    },


    // decrease Text size
    2: function () {
        if (accesiblityBtn) {
            console.log("2")
            for (var i = 0; i < textEl.length; i++) { // 0
                for (var j = 0; j < textEl[i].length; j++) { // 0
                    var style = window.getComputedStyle(textEl[i][j], null).getPropertyValue('font-size');
                    var fontSize = parseFloat(style);
                    textEl[i][j].style.fontSize = (fontSize - 2) + "px";
                }
            }
        }
    },
    //Grey Scale Funtion
    3: function () {
        if (accesiblityFuncControl) {
            console.log(document.querySelector("HTML").getAttribute("style"));

            if (document.querySelector("HTML").getAttribute("style") != " -moz-filter: grayscale(100%); - webkit-filter: grayscale(100%); filter: gray; /* IE6-9 */ filter: grayscale(100%)") {
                document.querySelector("HTML").setAttribute("style", " -moz-filter: grayscale(100%); - webkit-filter: grayscale(100%); filter: gray; /* IE6-9 */ filter: grayscale(100%)");
            }
            else {
                document.querySelector("HTML").setAttribute("style", null);
            }

        }
    },
    4: function () {
        if (accesiblityFuncControl) {
            if (!highContrast) {
                console.log("3")
                for (var i = 0; i < containerEl.length; i++) { // 0
                    containerEl[i].style.background = "Black";
                }

                //table 
                $("td").css({ "color": "white", "border-bottom":"1px solid rgba(249,250,250,0.5)" });
                $("th input").css({ "color": "" });
                $("tr").css({ "background": "black"});

                //Buttons & links
                $("button").css({ "background": "black" });
                $("a,li,input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#600040" : "transparent")
                })
                $("button,.button-menu, .btn-info, .btn-warning, .btn-dark, .inner-flex-container-right-items,.search-bar").css({ "border": "1px solid white" });
                $("button, .btn-info, .button-menu").css({ "color": "#27a9f8" });
                $("a").css({ "color": "#27a9f8" });

                //

                //Text
                $("strong").css({ "color": "yellow" });
                $("span").css({ "color": "#FFF" });
                $("h2").css({ "color": "#27a9f8" });
                $("h3").css({ "color": "#7460ee" });
                $("p,form input,select").css({ "color": "white" });
                $("select option").css({ "background": "black"});
                $("label").css({ "color": "yellow" });
                $("label").css({ "color": "yellow" });
                $("hr").css({ "background": "white" });

                    
                //Svg
                $("path").css({ "fill": "#27a9f8" });

                //list items
                $("li").css({ "border": "1px solid #27a9f8" });

                //WCAG Body
                $(".accesiblity-body").css({ "background": "black" });
                $(".accesiblity-body span, select option").css({ "color": "#27a9f8" });
                $(".accesiblity-body ul, select option ").css({ "border": "1px solid #27a9f8" });

                //Filter body
                $('.card').attr('style', "background: black!important; border: 1px solid #27a9f8 ");
                $(".btn-warning").css({ "color": "#27a9f8" });


                //status-flex-box-items
                $(".inner-flex-container-right-items, button,.search-bar, .btn-info, .button-menu, .btn-warning, .btn-dark").css({ "background": "rgba(39, 169, 248, 0.25)" });

                $(".inner-flex-container-right-items, button,.search-bar, .btn-info, .button-menu, .btn-warning, .btn-dark ").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#600040 " : "rgba(39, 169, 248, 0.25)")
                })


                //Search bar
                $("#searchBar").css({ "background": "transparent" });      

                //Details container
                $(".inner-details-container-one, .inner-details-container-two").css({ "background": "black", "border": "1px solid #27a9f8" });


                //Create page btns
                $(".form-row input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#600040 " : "rgba(162,179,187,0.2)")
                });
                $(".button-menu input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#600040" : "transparent")
                })
                $(".form-row select").focusin(function () {
                    $(this).css({ "background": "rgba(162,179,187,0.2)" });
                });

                //Set Cookie to pass to other pages
                setCookie("HighC","True",1)

                highContrast = true;

            }
            else {
                for (var i = 0; i < containerEl.length; i++) { // 0
                    containerEl[i].style.background = "white";
                }

                //table 
                $("td").css({ "color": "black","border":"none" });
                $("th input").removeAttr("style");
                $("tr").removeAttr("style");

                //Buttons & links
                $("button").removeAttr("style");;
                $("a,li,input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "transparent" : "transparent")
                })
               // $("button,.inner-flex-container-right-items,.search-bar").removeAttr("style");
                $("button, .btn-info").removeAttr("style");
                $("li a").removeAttr("style");

                //

                //Text
                $("strong").removeAttr("style");
                $("span").removeAttr("style");
                $(".details-headings  h2").css({ "color": "#7460ee" });      
                $("h3").removeAttr("style");
                $("p,form input,select").removeAttr("style");
                $("select option").removeAttr("style");
                $("label").removeAttr("style");
                $("label").removeAttr("style");
                $("hr").removeAttr("style");


                //Svg
                $("path").removeAttr("style");

                //list items
                $("li").removeAttr("style");

                //WCAG Body
                $(".accesiblity-body").removeAttr("style");
                $(".accesiblity-body span, select option").removeAttr("style");
                $(".accesiblity-body ul, select option ").removeAttr("style");

                //status-flex-box-items
                $(".body").css({ "background": "#f9fafa" });
                $("#filterToggle").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "white" : "white")
                })
                $("#filterToggle").css({ "background": "white" });
                $(".inner-flex-container-right a").css({ "background": "#27a9f8"});
                $(".inner-flex-container-right a").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#27a9f8" : "#27a9f8")
                });

                $("#moreOptions").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "rgba(39,169,248,0.25)" : "rgba(39,169,248,0.25)")
                });

                $(".search-bar").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "transparent" : "transparent")
                })

                //Filter body
                $('.card').attr('style', "background: white!important; border: 1px solid rgba(39,169,248,0.3); ");
                $('.collapse .btn-warning').attr('style', "width: 20% ");
                $('.collapse .btn-dark').attr('style', "width: 20%; margin-left: 2%; ");


                //Search bar
                $("#searchBar").removeAttr("style");
                $(".details-menu .btn-primary").css({ "width": '12%', 'margin-right': '3.5%', 'background': '#1b6ec2'});
                $(".btn-success").css({ 'background': '#28a745' });
                $(".btn-dark").css({ 'background': '#343a40' });
                $(".btn-primary a").css({ 'color': "white" });
                $(".btn-info").css({"float": "right", "width": "19%" });
                $(".btn-danger").css({
                    "width": '17%', 'background': '#dc3545' });
             

                $(".details-menu .btn-primary").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#1b6ec2" : "#1b6ec2")
                });
                $(".btn-info").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#17a2b8" : "#17a2b8")
                });
                $(".btn-danger").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#dc3545" : "#dc3545")
                });
                $(".btn-success").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#28a745" : "#28a745")
                });
                $(".btn-dark").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "#343a40" : "#343a40")
                });


                $(".search-bar").removeAttr("style");

                //Details container
                $(".inner-details-container-one, .inner-details-container-two").removeAttr("style");


                //Create page btns
                $(".form-row input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "rgba(162,179,187,0.2)" : "rgba(162,179,187,0.2)")
                });
                $(".button-menu input").hover(function (e) {
                    $(this).css("background-color", e.type === "mouseenter" ? "transparent" : "transparent")
                })
                $(".form-row select").focusin(function () {
                    $(this).css({ "background": "rgba(162,179,187,0.2)" });
                });

                //Delete Cookie seting -1 as expire
                setCookie("HighC", "", -1)

                highContrast = false;

            }
        }

    },
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


console.log(getCookie("HighC"))

if (getCookie("HighC")) {
    functions[4]();
    console.log('c')
}