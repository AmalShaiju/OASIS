// Amal shaiju 2021-03-13

var strict = false;
var budget = 0;

//lock if the record already has a budget
Updatelock()
Budgeting(budget, runningTotal, strict);

$(".lock").click(function () {

    Updatelock();
    Budgeting(budget, runningTotal, strict);

});

$('#Budget').change(function () {

    updateBidBudget();
    Budgeting(budget, runningTotal, strict)

});

function Updatelock() {

    if (($(".lock").css("background-image").replace('url(', '').replace(')', '').replace(/\"/gi, "")).includes("lock-open.svg")) {


        inputTxt = $("#Budget").val();


        if (inputTxt == "") {

            //Empty input add display "$0" 
            //alert("Please Insert a budget before locking")
        }
        else {

            //lock icon 
            $(".lock").css('background', `url("${getBaseUrl()}resources/svg/lock-closed.svg") center no-repeat`);

            // Disable the input
            $("#Budget").attr("disabled", true)

            // Add "$" to input and display
            $("#Budget").val($("#Budget").val())


            strict = true;

            //Populate bid budget in table
            updateBidBudget();

        }


    }
    else {
        //open
        $(".lock").css('background', `url("${getBaseUrl()}resources/svg/lock-open.svg") center no-repeat`);

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

}

function updateBidBudget() {


    if ($("#Budget").val() == "") {

        // empty input change budget in table to null
        $(".budget").text("");

        //change budget back to 0
        budget = 0;
    }
    else {
        console.log("before - " + $("#Budget").val());

        //Change budget since input changed
        $(".budget").text(`B: $${$("#Budget").val()} `);


        // change budget variable to new input
        budget = parseFloat($("#Budget").val().split("$").pop());

    }
}

function Budgeting(budget, runningTotal, strict) {
    console.log("entered");
    if ((runningTotal > budget) && (budget != 0)) {

        $("#bidRoleTotal").css("color", "#ffcccb")
        $("#bidProductTotal").css("color", "#ffcccb")

        if (strict) {

            $('#btnSubmit').attr("disabled", true);
            $('#createEmployee').attr("disabled", true);
            $('#createCustomer').attr("disabled", true);
            $('#createProject').attr("disabled", true);

        }
        else {
            $('#btnSubmit').attr("disabled", false);
            $('#createEmployee').attr("disabled", false);
            $('#createCustomer').attr("disabled", false);
            $('#createProject').attr("disabled", false);
        }
    }
    else {
        $("#bidRoleTotal").css("color", "#90ee90")
        $("#bidProductTotal").css("color", "#90ee90")

        $('#btnSubmit').attr("disabled", false);
        $('#createEmployee').attr("disabled", false);
        $('#createCustomer').attr("disabled", false);
        $('#createProject').attr("disabled", false);

    }



}