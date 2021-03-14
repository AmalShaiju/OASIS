// Amal shaiju 2021-03-13

var strict = false;
var budget = 0;

$(".lock").click(function () {

    console.log($(this).css("background-image").replace('url(', '').replace(')', '').replace(/\"/gi, ""));

    if ($(this).css("background-image").replace('url(', '').replace(')', '').replace(/\"/gi, "") == "http://localhost:63341/resources/svg/lock-open.svg") {

        //lock 
        $(this).css('background', `url("${getBaseUrl()}resources/svg/lock-closed.svg") center no-repeat`);

        // Disable the input
        $("#Budget").attr("disabled", true)

        inputTxt = $("#Budget").val();


        if (inputTxt == "") {

            //Empty input add display "$0" 
            $("#Budget").val("$" + 0)
        }
        else {

            // Add "$" to input and display
            $("#Budget").val("$" + $("#Budget").val())
        }
        strict = true;


    }
    else {
        //open
        $(this).css('background', `url("${getBaseUrl()}resources/svg/lock-open.svg") center no-repeat`);

        // Make the input avaiable to edit
        $("#Budget").attr("disabled", false)

        // txt inputed
        inputTxt = $("#Budget").val();

        if (inputTxt == "$0") {

            // inputed empty so display nothing
            $("#Budget").val("");
        }
        else {
            // Remvoe "$" from text and display it back
            $("#Budget").val(inputTxt.split('$').pop());
        }

        strict = false;


    }
    Budgeting(budget, runningTotal, strict) 

});

$('#Budget').change(function () {

    if ($("#Budget").val() == "") {

        // empty input change budget in table to null
        $(".budget").text("");

        //change budget back to 0
        budget = 0;
    }
    else {
        //Change budget since input changed
        $(".budget").text(`B: $${$("#Budget").val()} `);

        // change budget variable to new input
        budget = parseFloat($("#Budget").val());

    }
});

function Budgeting(budget, runningTotal, strict) {
    if (strict) {

        if ((runningTotal > budget) && (budget != 0)) {

            $("#bidRoleTotal").css("color", "red")
            $("#bidProductTotal").css("color", "red")

            $('#btnSubmit').attr("disabled", true);

        }
        else {

            $("#bidRoleTotal").removeAttr('style');
            $("#bidProductTotal").removeAttr('style');

            $('#btnSubmit').attr("disabled", false);

        }


    }
    else {

        $("#bidRoleTotal").removeAttr('style');
        $("#bidProductTotal").removeAttr('style');

        $('#btnSubmit').attr("disabled", false);

    }

}